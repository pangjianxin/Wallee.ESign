using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;
using Volo.Abp.Timing;
using Wallee.ESign.HttpClientExtensions;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.RemoteApi
{
    public class RemoteApi : IRemoteApi, ITransientDependency
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IClock _clock;
        private readonly ESignOptions _options;

        public RemoteApi(
            IHttpClientFactory httpClientFactory,
            IJsonSerializer jsonSerializer,
            IOptions<ESignOptions> options,
            IClock clock)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializer = jsonSerializer;
            _clock = clock;
            _options = options.Value;
        }
        public async Task<ESignAuthResponseDto> PersonalTelecom3Factors(CreatePersonalTelecom3FactorsDto input)
        {
            var requestUrl = "/v2/identity/auth/api/individual/telecom3Factors";

            var jsonData = _jsonSerializer.Serialize(input);

            var headers = new Dictionary<string, string>()
            {
                {"Accept","*/*" },
                {"Content-MD5","" },
                {"Content-Type","application/json;charset=UTF-8" },
                {"X-Tsign-Open-App-Id",_options.AppId},
                {"X-Tsign-Open-Ca-Timestamp",$"{_clock.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds}"},
                {"X-Tsign-Open-Auth-Mode","Signature" },
                {"X-Tsign-Open-Ca-Signature","" },
            };

            CalculateContentMd5(jsonData, ref headers);

            CalculateSignature("POST", requestUrl, ref headers);

            var httpClient = _httpClientFactory.CreateClient("esign");

            var response = await httpClient.PostWithHeadersAsync(requestUrl, headers, jsonData);

            return _jsonSerializer.Deserialize<ESignAuthResponseDto>(await response.Content.ReadAsStringAsync());
        }
        private void CalculateContentMd5(string jsonData, ref Dictionary<string, string> headers)
        {
            var md5Bytes = MD5.HashData(Encoding.UTF8.GetBytes(jsonData));

            headers["Content-MD5"] = Convert.ToBase64String(md5Bytes);
        }
        private void CalculateSignature(string httpMethod, string url, ref Dictionary<string, string> headers)
        {
            var stringToSign = new StringBuilder(httpMethod + "\n");

            stringToSign.Append(headers["Accept"] + "\n");
            stringToSign.Append(headers["Content-MD5"] + "\n");
            stringToSign.Append(headers["Content-Type"] + "\n");
            stringToSign.Append(url);

            using HMACSHA256 mac = new(_options.AppId.GetBytes());

            byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign.ToString()));

            var signature = Convert.ToBase64String(hash);

            headers["X-Tsign-Open-Ca-Signature"] = signature;
        }
    }
}
