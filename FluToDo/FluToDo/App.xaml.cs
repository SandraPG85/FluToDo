using FluToDo.Core;
using FluToDo.Services;
using FluToDo.Views;

using Xamarin.Forms;

namespace FluToDo
{
    public partial class App : Application
    {
        public static ITodoManager TodoManager { get; private set; }
        public static INavigationService NavigationService { get; set; }

        public App()
        {
            InitializeComponent();
            TodoRestService ToDoService = new TodoRestService(Constants.ToDoRestUrl, new HttpHandler());
            IAlertService alertService = new AlertService();
            TodoManager = new TodoManager(ToDoService, alertService);
            NavigationPage navPage = new NavigationPage(new TodoListPage());
            MainPage = navPage;
            NavigationService = new NavigationService(navPage);
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
