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
        private bool _isRefreshing = false;

        public TodoListViewModel(ITodoManager todoManager)
        {
            this.todoManager = todoManager;
            this.TodoList = new ObservableCollection<TodoViewModel>();
            this.todoManager.Initialize(this.TodoList);

            this.LoadTodosCommand = new Command(async () => { await this.todoManager.LoadTodosAsync(); });
            this.NewTodoCommand = new Command(async () => { await App.NavigationService.PushAsync(new TodoCreationPage()); });
            this.DeleteCommand = new Command<TodoViewModel>(async (todo) => { await this.todoManager.DeleteTodoAsync(todo); });
            this.DoneCommand = new Command<TodoViewModel>(async (todo) => { await this.todoManager.UpdateTodoAsync(todo); });
            this.RefreshCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await this.todoManager.LoadTodosAsync();
                IsRefreshing = false;
            });
        }

        public bool IsRefreshing
        {
            get { return this._isRefreshing; }
            set
            {
                this._isRefreshing = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<TodoViewModel> TodoList { get; private set; }

        public ICommand LoadTodosCommand { get; private set; }
        public ICommand NewTodoCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand DoneCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
    }
}
