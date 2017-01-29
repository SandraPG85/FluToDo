using FluToDo.Core;
using FluToDo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.Services
{
    internal sealed class TodoRestService : ITodoRestService
    {
        private readonly IHttpHandler client;
        private readonly string apiUrl;


        public TodoRestService(string apiUrl, IHttpHandler client)
        {
            this.apiUrl = apiUrl;
            this.client = client;
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            List<TodoItem> Items = new List<TodoItem>();

            var uri = new Uri(string.Format(this.apiUrl, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveToDoItemAsync(TodoItem item)
        {
            Uri uri = new Uri(string.Format(this.apiUrl, string.Empty));

            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, Constants.JsonMediaType);

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);
        }

        public async Task DeleteToDoItemAsync(string id)
        {
            Uri uri = new Uri(string.Format(this.apiUrl, id));
            var response = await client.DeleteAsync(uri);
        }
    }
}
