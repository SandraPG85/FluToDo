using System.Collections.ObjectModel;
using FluToDo.Core;
using System.Windows.Input;
using Xamarin.Forms;

namespace FluToDo.ViewModels
{
    internal class TodoListViewModel : ViewModelBase
    {
        private ITodoManager todoManager;

        public TodoListViewModel(ITodoManager todoManager)
        {
            this.todoManager = todoManager;
            this.TodoList = new ObservableCollection<TodoViewModel>();
            this.todoManager.Initialize(this.TodoList);

            this.LoadTodosCommand = new Command(async () => { await this.todoManager.LoadTodosAsync(); });
        }

        public ObservableCollection<TodoViewModel> TodoList { get; private set; }

        public ICommand LoadTodosCommand { get; private set; }
    }
}
