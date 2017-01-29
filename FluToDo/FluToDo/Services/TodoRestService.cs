using FluToDo.Core;
using FluToDo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.Services
{
    internal sealed class TodoRestService : ITodoRestService
    {
        private readonly IHttpHandler client;
        private readonly string apiUrl;

        private List<TodoItem> items;

        public TodoRestService(string apiUrl, IHttpHandler client)
        {
            this.apiUrl = apiUrl;
            this.client = client;
            this.items = new List<TodoItem>();
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            this.items.Clear();

            var uri = new Uri(string.Format(this.apiUrl, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    this.items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return this.items;
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

        public async Task UpdateToDoItemAsync(string id)
        {
            Uri uri = new Uri(string.Format(this.apiUrl, id));

            TodoItem item = this.items.Where(x => x.Key == id).First();
            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, Constants.JsonMediaType);

            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);
        }
    }
}
