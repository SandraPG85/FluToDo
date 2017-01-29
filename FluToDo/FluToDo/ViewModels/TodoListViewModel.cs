using System.Collections.ObjectModel;
using FluToDo.Core;
using System.Windows.Input;
using Xamarin.Forms;
using FluToDo.Views;

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
            this.NewTodoCommand = new Command(async () => { await App.NavigationService.PushAsync(new TodoCreationPage()); });
        }

        public ObservableCollection<TodoViewModel> TodoList { get; private set; }

        public ICommand LoadTodosCommand { get; private set; }
        public ICommand NewTodoCommand { get; private set; }
    }
}
