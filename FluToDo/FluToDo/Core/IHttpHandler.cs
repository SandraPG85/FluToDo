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

        /// <summary>
        /// Posts a request asynchronosuly to the given Uri
        /// </summary>
        Task<HttpResponseMessage> PostAsync(Uri url, HttpContent content);

        /// <summary>
        /// Delete request asynchronosuly to the given Uri
        /// </summary>
        Task<HttpResponseMessage> DeleteAsync(Uri url);

        /// <summary>
        /// Puts a request asynchronosuly to the given Uri
        /// </summary>
        Task<HttpResponseMessage> PutAsync(Uri url, HttpContent content);
    }
}
