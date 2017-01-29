
using FluToDo.Core;
using FluToDo.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FluToDo.Views
{
    public partial class TodoListPage : ContentPage
    {
        TodoListViewModel viewModel;

        public TodoListPage()
        {
            InitializeComponent();
            this.viewModel = new TodoListViewModel(App.TodoManager);
            base.BindingContext = this.viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() => this.viewModel.LoadTodosCommand.Execute(null));
        }
    }
}
