using FluToDo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluToDo.Services
{
    /// <summary>
    /// rest service used to retrieve the Todo information from a remote service
    /// </summary>
    public interface ITodoRestService
    {
        /// <summary>
        /// Retrieve the data asynchronously from the remote service
        /// </summary>
        Task<List<TodoItem>> RefreshDataAsync();

        /// <summary>
        /// Saves the todo asynchronously to the remote service
        /// </summary>
        Task SaveToDoItemAsync(TodoItem item);

        /// <summary>
        /// Deletes a todo asynchronously to the remote service
        /// </summary>
        Task DeleteToDoItemAsync(string id);
    }
}
