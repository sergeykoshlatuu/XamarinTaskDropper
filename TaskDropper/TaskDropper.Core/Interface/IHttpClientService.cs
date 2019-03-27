using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TaskDropper.Core.Interface
{
    public interface IHttpClientService
    {
        HttpClient GetHttpClient(string token);
    }
}
