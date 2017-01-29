﻿using FluToDo.Models;
using FluToDo.Services;
using FluToDo.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FluToDo.Core
{
    internal class TodoManager : ITodoManager
    {
        private readonly ITodoRestService todoRestService;
        private ObservableCollection<TodoViewModel> todoList;

        public TodoManager(ITodoRestService todoRestService)
        {
            this.todoRestService = todoRestService;
        }

        public void Initialize(ObservableCollection<TodoViewModel> todoList)
        {
            this.todoList = todoList;
        }

        public async Task LoadTodosAsync()
        {
            List<TodoItem> todos = await this.todoRestService.RefreshDataAsync();
            this.todoList.Clear();
            foreach (var todo in todos)
            {
                this.todoList.Add(new TodoViewModel(todo));
            }
        }
    }
}