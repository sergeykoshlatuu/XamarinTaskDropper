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
        HttpClient httpClient;
        
        public List<ItemTask> Items { get; private set; }
        string RestUrl = "http://10.10.3.183:50176/api/task/";
        private IDatabaseTaskService _databaseTaskService;
        private IDatabaseUserService _databaseUserService;
        string token=null;
 
        public TaskWebApiService(IDatabaseTaskService databaseTaskService, IDatabaseUserService databaseUserService)
        {
            httpClient = new HttpClient();
            _databaseTaskService = databaseTaskService;
            _databaseUserService = databaseUserService;
            

        }

        public async Task RefreshDataAsync(string email)
        {
            try
            {
                Items = new List<ItemTask>();

                if (token == null)
                {
                    token = await GetToken();
                }
                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", token);
                string templateUrl = RestUrl + "?&id=" + email;
                var uri = new Uri(templateUrl);
                
               
                

                var response = await httpClient.GetAsync(uri);
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
            string tokenUrl = "http://10.10.3.183:50176/api/token/?email=" + lastUser.Email+"&token="+lastUser.Token;
            var response = await httpClient.GetAsync(tokenUrl);
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

                if (token == null)
                {
                    token = await GetToken();
                }
                httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Bearer", token);
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await httpClient.PostAsync(uri, content);
                }
                else
                {
                    string templateUrl = RestUrl + "?id=" + item.Id;
                    uri = new Uri(string.Format(templateUrl, string.Empty));
                    response = await httpClient.PutAsync(uri, content);
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

                if (token == null)
                {
                    token = await GetToken();
                }
                httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.DeleteAsync(uri);

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
