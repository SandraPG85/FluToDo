using FluToDo.Core;
using FluToDo.Services;
using FluToDo.Views;

using Xamarin.Forms;

namespace FluToDo
{
    public partial class App : Application
    {
        public static ITodoRestService ToDoService { get; private set; }

        public App()
        {
            InitializeComponent();
            ToDoService = new TodoRestService(Constants.ToDoRestUrl, new HttpHandler());
            NavigationPage navPage = new NavigationPage(new TodoListPage());
            MainPage = navPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
