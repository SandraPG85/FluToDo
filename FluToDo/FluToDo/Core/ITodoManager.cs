using FluToDo.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FluToDo.Core
{
    /// <summary>
    /// Manages the todo list
    /// </summary>
    internal interface ITodoManager
    {
        /// <summary>
        /// Initializes the manger with the todo list collection
        /// </summary>
        void Initialize(ObservableCollection<TodoViewModel> todoList);

        /// <summary>
        /// Loads the todo list collection asynchronously
        /// </summary>
        Task LoadTodosAsync();
    }
}
