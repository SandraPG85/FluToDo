using System;
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
    }
}
