using FluToDo.Models;
using FluToDo.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FluToDo.Core
{
    /// <summary>
    /// Manages the todo list
    /// </summary>
    public interface ITodoManager
    {
        /// <summary>
        /// Initializes the manger with the todo list collection
        /// </summary>
        void Initialize(ObservableCollection<TodoViewModel> todoList);

        /// <summary>
        /// Loads the todo list collection asynchronously
        /// </summary>
        Task LoadTodosAsync();

        /// <summary>
        /// Creates a todo and updates the remote service
        /// </summary>
        Task CreateTodoAsync(string item);

        /// <summary>
        /// Deletes a todo and updates the remote service
        /// </summary>
        Task DeleteTodoAsync(TodoViewModel todo);

        /// <summary>
        /// Updates a todo and updates the remote service
        /// </summary>
        Task UpdateTodoAsync(TodoViewModel todo);
    }
}
