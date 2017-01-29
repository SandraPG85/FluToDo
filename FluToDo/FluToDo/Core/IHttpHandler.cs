using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluToDo.Core
{
    /// <summary>
    /// Handles the Http operations required by the application
    /// </summary>
    public interface IHttpHandler
    {
        /// <summary>
        /// Get a response asynchronosuly from a given Uri
        /// </summary>
        Task<HttpResponseMessage> GetAsync(Uri url);
    }
}
