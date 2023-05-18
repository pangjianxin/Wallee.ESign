using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
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
            var content = _jsonSerializer.Serialize(input);
            var contentMd5 = CalculateContentMd5(content);
            var appKey = _options.AppSecret;
            var httpMethod = "POST";
            var requestHeaders = new Dictionary<string, string>()
            {
                {"Accept","application/json" },
                {"X-Tsign-Open-Ca-Timestamp",$"{_clock.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds:F0}"},
                {"X-Tsign-Open-Ca-Signature","" },
            };

            CalculateSignature(appKey, httpMethod, contentMd5, requestUrl, ref requestHeaders);
            using var httpClient = _httpClientFactory.CreateClient("esign");
            var response = await httpClient.PostESignWithJson(requestUrl, requestHeaders, content, contentMd5);
            return _jsonSerializer.Deserialize<ESignAuthResponseDto>(await response.Content.ReadAsStringAsync());
        }

        private static string CalculateContentMd5(string jsonData)
        {
            byte[] md5Bytes = MD5.HashData(jsonData.GetBytes());
            return Convert.ToBase64String(md5Bytes).ToString();
        }

        private static void CalculateSignature(string key, string httpMethod, string contentMd5, string url, ref Dictionary<string, string> headers)
        {
            var stringToSign = ManipulateStringToSign(httpMethod, headers["Accept"], contentMd5, "application/json", url);

            using HMACSHA256 mac = new(key.GetBytes());
            byte[] hash = mac.ComputeHash(stringToSign.GetBytes());
            var signature = Convert.ToBase64String(hash);
            headers["X-Tsign-Open-Ca-Signature"] = signature;

            string ManipulateStringToSign(string httpMethod, string accept, string contentMd5, string contentType, string url, string? date = null, string? headers = null)
            {
                //https://open.esign.cn/doc/opendoc/identity_service/tdcmzo
                var stringToSign = httpMethod + "\n" + accept + "\n" + contentMd5 + "\n" + contentType + "\n" + date + "\n";
                if (headers != null)
                {
                    stringToSign += headers + "\n";
                }
                stringToSign += url;

                return stringToSign;
            }
        }
    }
}
