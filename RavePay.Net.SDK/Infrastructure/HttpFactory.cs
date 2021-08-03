using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RavePay.Net.SDK.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static HttpClient InitHttpClient()
        {
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();

            return client;
        }

        /// <summary>
        /// Adds BaseUri
        /// </summary>
        /// <param name="client"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public static HttpClient WithBaseUri(this HttpClient client, string baseUrl)
        {
            client.BaseAddress = new Uri(baseUrl);
            return client;
        }

        /// <summary>
        /// Add Mediatype to httpClient
        /// </summary>
        /// <param name="client"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static HttpClient AddMediaType(this HttpClient client, string mediaType)
        {
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue(mediaType));

            return client;
        }

        /// <summary>
        /// Add header key and value
        /// </summary>
        /// <param name="client"></param>
        /// <param name="headerKey"></param>
        /// <param name="headerVal"></param>
        /// <returns></returns>
        public static HttpClient AddHeader(this HttpClient client, string headerKey, string headerVal)
        {
            client.DefaultRequestHeaders.Add(headerKey, headerVal);

            return client;
        }

        /// <summary>
        /// Add Authorization Header
        /// </summary>
        /// <param name="client"></param>
        /// <param name="authType"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static HttpClient AddAuthorizationHeader(this HttpClient client, string authType, string secretKey)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authType, secretKey);

            return client;
        }
    }
}
