using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TaskDropper.Core.Interface;

namespace TaskDropper.Core.Services
{
    public class HttpClientService : IHttpClientService
    {
        HttpClient httpClient;

        public HttpClient GetHttpClient(string token)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            return httpClient;
        }
    }
}
