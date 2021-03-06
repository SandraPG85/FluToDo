﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluToDo.Core
{
    internal sealed class HttpHandler : IHttpHandler
    {
        private readonly HttpClient _client;

        public HttpHandler()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(Uri url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Uri url)
        {
            return await _client.DeleteAsync(url);
        }

        public async Task<HttpResponseMessage> PutAsync(Uri url, HttpContent content)
        {
            return await _client.PutAsync(url, content);
        }
    }
}
