﻿using FluToDo.Core;
using FluToDo.Models;
using FluToDo.Services;
using FluToDo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FluToDo.Tests
{
    /// <summary>
    /// Summary description for TodoManagerTest
    /// </summary>
    [TestClass]
    public class TodoManagerTest
    {

        [TestMethod]
        public void LoadTodosAsync_HostAvailable_RetrieveOk()
        {
            // Arrange
            ObservableCollection<TodoViewModel> todoList = new ObservableCollection<TodoViewModel>();
            List<TodoItem> remoteTodos = new List<TodoItem>();
            remoteTodos.Add(new TodoItem() { Name = "Test", Key = "key" });

            ITodoRestService todoService = MockRepository.GenerateStub<ITodoRestService>();
            todoService.Stub(s => s.RefreshDataAsync()).Return(Task.FromResult(remoteTodos));

            // Act
            ITodoManager sut = new TodoManager(todoService);
            sut.Initialize(todoList);
            sut.LoadTodosAsync();

            // Assert
            Assert.AreEqual(1, todoList.Count);
            Assert.AreEqual("Test", todoList[0].Name);
        }
    }
}
