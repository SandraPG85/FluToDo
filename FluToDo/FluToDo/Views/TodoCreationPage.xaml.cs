
using FluToDo.ViewModels;
using Xamarin.Forms;

namespace FluToDo.Views
{
    public partial class TodoCreationPage : ContentPage
    {
        public TodoCreationPage()
        {
            InitializeComponent();
            this.BindingContext = new TodoCreationViewModel(App.TodoManager);
        }
    }
}
