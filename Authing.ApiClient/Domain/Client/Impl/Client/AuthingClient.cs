﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Authing.ApiClient.Infrastructure.GraphQL;
using Authing.ApiClient.Types;
using Newtonsoft.Json;
using HttpMethod = System.Net.Http.HttpMethod;

namespace Authing.ApiClient.Domain.Client.Impl.Client
{
    public class AuthingClient : IAuthingClient
    {
        public async Task<TResponse> SendRequest<TRequest, TResponse>(string url, HttpType httpType, TRequest body,
            Dictionary<string, string> headers)
        {
            if (body is string s)
            {
                return await SendRequest<TResponse>(url, s, headers, httpType);
            }
            else
            {
                var bodyStr = JsonConvert.SerializeObject(
                    body,
                    Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                return await SendRequest<TResponse>(url, bodyStr, headers, httpType);
            }
        }

        public async Task<TResponse> SendRequest<TRequest, TResponse>(string url, HttpType httpType, Dictionary<string, string> body,
    Dictionary<string, string> headers)
        {
            return await SendRequest<TResponse>(url, body, headers, httpType);
        }


        private AuthingClient()
        {
        }

        public static AuthingClient CreateAhtingClient()
        {
            return new AuthingClient();
        }

        private async Task<TResponse> SendRequest<TResponse>(string url, string strContent,
            Dictionary<string, string> headers, HttpType httpType = HttpType.Post)
        {

            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);

            HttpRequestMessage message = null;

            if (httpType == HttpType.Get)
            {
                message = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            }
            else if (httpType == HttpType.Delete)
            {
                message =   new HttpRequestMessage(HttpMethod.Delete, new Uri(url));
            }
            else
            {
                message = new HttpRequestMessage(HttpMethod.Post, new Uri(url))
                {
                    Content = new StringContent(strContent, Encoding.UTF8, "application/json")
                };
            }

            if (headers != null)
            {
                foreach (var keyValuePair in headers)
                {
                    message.Headers.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            using (var httpResponseMessage =
                await new HttpClient().SendAsync(message, HttpCompletionOption.ResponseHeadersRead))
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using (var reader = new StreamReader(contentStream))
                    {
                        var resString = await reader.ReadToEndAsync();
                        return JsonConvert.DeserializeObject<TResponse>(resString);
                    }
                }

                // error handling
                string content = null;
                if (contentStream != null)
                    using (var sr = new StreamReader(contentStream))
                        content = await sr.ReadToEndAsync();

                throw new Exception("Error");
            }
        }


        private async Task<TResponse> SendRequest<TResponse>(string url, Dictionary<string, string> body,
           Dictionary<string, string> headers, HttpType httpType = HttpType.Post)
        {

            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);

            HttpRequestMessage message = null;

            if (httpType == HttpType.Get)
            {
                message = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            }
            else if (httpType == HttpType.Delete)
            {
                message = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            }
            else
            {
                SortedDictionary<string, string> sortedParam = new SortedDictionary<string, string>(body.ToDictionary(x => x.Key, x => x.Value.ToString()));
                message = new HttpRequestMessage(HttpMethod.Post, new Uri(url))
                {
                    Content = new FormUrlEncodedContent(sortedParam)
                };
            }

            if (headers != null)
            {
                foreach (var keyValuePair in headers)
                {
                    message.Headers.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            using (var httpResponseMessage =
                await new HttpClient().SendAsync(message, HttpCompletionOption.ResponseHeadersRead))
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using (var reader = new StreamReader(contentStream))
                    {
                        var resString = await reader.ReadToEndAsync();
                        return JsonConvert.DeserializeObject<TResponse>(resString);
                    }
                }

                // error handling
                string content = null;
                if (contentStream != null)
                    using (var sr = new StreamReader(contentStream))
                        content = await sr.ReadToEndAsync();

                throw new Exception("Error");
            }
        }
    }
}