using System;
using System.Collections.Generic;
using System.Linq;
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

        public static async Task<HttpResponseMessage> PostWithHeadersAsync(this HttpClient httpClient, string requestUri, Dictionary<string, string> headers, string? jsonData = null)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            if (jsonData != null)
            {
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                request.Content = stringContent;
            }

            return await httpClient.SendAsync(request);
        }
    }
}
