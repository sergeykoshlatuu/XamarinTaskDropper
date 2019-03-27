using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Models;

namespace TaskDropper.Core.Services
{
    public class TaskWebApiService : ITaskWebApiService
    {
       
        private IHttpClientService _httpClientService;
        public List<ItemTask> Items { get; private set; }
        string RestUrl = "http://10.10.3.183:50176/api/task/";
        private IDatabaseTaskService _databaseTaskService;
        private IDatabaseUserService _databaseUserService;
        string token;
 
        public TaskWebApiService(IDatabaseTaskService databaseTaskService,
            IDatabaseUserService databaseUserService,
            IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _databaseTaskService = databaseTaskService;
            _databaseUserService = databaseUserService;
        }

        public async Task RefreshDataAsync(string email)
        {
            try
            {
                Items = new List<ItemTask>();

                string templateUrl = RestUrl + "?&id=" + email;
                var uri = new Uri(templateUrl);
                
                var response = await _httpClientService.GetHttpClient(token).GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    _httpClientService.GetHttpClient(token).DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                    token = await RefreshToken(token);
                   
                }
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<ItemTask>>(content);
                    _databaseTaskService.UpdateLocalDatabese(Items);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            Console.WriteLine(Items);
        }

        public async Task<string> GetToken()
        {
            LastUser lastUser = _databaseUserService.GetLastUser();
            string tokenUrl = "http://10.10.3.183:50176/api/token/get/?email=" + lastUser.Email+"&token="+lastUser.Token;
            var response = await _httpClientService.GetHttpClient(token).GetAsync(tokenUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<string>(content);
                token = content;
                return content;
            }
            return null;
        }

        public async Task<string> RefreshToken(string oldToken)
        {
            LastUser lastUser = _databaseUserService.GetLastUser();

            string tokenUrl = "http://10.10.3.183:50176/api/token/RefreshToken/?oldToken=" + oldToken + "&email=" +lastUser.Email ;
            var response = await _httpClientService.GetHttpClient(token).GetAsync(tokenUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<string>(content);

                return content;
            }
            return null;
        }

        public async Task SaveItemTaskAsync(ItemTask item, bool isNewItem=false)
        {
            try
            {
                var uri = new Uri(string.Format(RestUrl, string.Empty));

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _httpClientService.GetHttpClient(token).PostAsync(uri, content);
                }
                else
                {
                    string templateUrl = RestUrl + "?id=" + item.Id;
                    uri = new Uri(string.Format(templateUrl, string.Empty));
                    response = await _httpClientService.GetHttpClient(token).PutAsync(uri, content);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    _httpClientService.GetHttpClient(token).DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                    token = await RefreshToken(token);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Task successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

        public async Task DeleteItemTaskAsync(string id)
        {
            try
            {
                string templateUrl = RestUrl + id;
                var uri = new Uri(string.Format(templateUrl));
                var response = await _httpClientService.GetHttpClient(token).DeleteAsync(uri);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    _httpClientService.GetHttpClient(token).DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                    token = await RefreshToken(token);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Task deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }

        }
 
    }
}
