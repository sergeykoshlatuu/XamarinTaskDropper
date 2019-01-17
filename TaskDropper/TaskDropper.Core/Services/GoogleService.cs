using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.Models;

namespace TaskDropper.Core.Services
{
    public class GoogleService
    {

        public async Task<string> GetEmailAsync(string tokenType, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
            var json = await httpClient.GetStringAsync("https://www.googleapis.com/userinfo/email?alt=json");
            var email = JsonConvert.DeserializeObject<GoogleEmail>(json);

            return email.Data.Email;
        }

        public async Task<string> GetGoogleUserProfileAsync(string tokenType, string accessToken)
        {

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
            var json = await httpClient.GetStringAsync("https://www.googleapis.com/userinfo/picture?alt=json");
            var email = JsonConvert.DeserializeObject<GoogleEmail>(json);

            return email.Data.Email;
        }
    }
}