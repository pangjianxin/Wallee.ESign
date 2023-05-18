using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wallee.ESign.HttpClientExtensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> GetWithHeadersAsync(this HttpClient httpClient, string requestUri, Dictionary<string, string> headers)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return await httpClient.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> PostESignWithJson(this HttpClient httpClient, string requestUri, Dictionary<string, string> requestHeaders, string content, string contentMd5)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            foreach (var header in requestHeaders)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            stringContent.Headers.ContentMD5 = Convert.FromBase64String(contentMd5);

            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            request.Content = stringContent;

            return await httpClient.SendAsync(request);
        }
    }
}
