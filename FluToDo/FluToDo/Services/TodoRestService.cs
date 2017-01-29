﻿using FluToDo.Core;
using FluToDo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}