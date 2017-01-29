using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Rhino.Mocks;
using FluToDo.Core;
using FluToDo.Services;
using System.Net.Http;
using FluToDo.Models;

namespace FluToDo.Tests
{
    /// <summary>
    /// Summary description for TodoRestServiceTest
    /// </summary>
    [TestClass]
    public class TodoRestServiceTest
    {
        [TestMethod]
        public async Task RefreshDataAsync_HostAvailable_RetrieveItemsOk()
        {
            // Arrange
            IHttpHandler httpHanlder = MockRepository.GenerateStub<IHttpHandler>();
            ITodoRestService sut = new TodoRestService("http://1.1.1.1", httpHanlder);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent("[{\"Key\":\"497c47c3-d7b8-4321-8750-47051c7bc0e4\",\"Name\":\"Item1\",\"IsComplete\":false}]");
            response.StatusCode = System.Net.HttpStatusCode.Accepted;

            httpHanlder.Stub(http => http.GetAsync(Arg<Uri>.Matches(x => x.AbsoluteUri == "http://1.1.1.1/"))).Return(Task.FromResult(response));

            // Act
            List<TodoItem> items = await sut.RefreshDataAsync();

            // Assert
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("Item1", items[0].Name);
        }
    }
}
