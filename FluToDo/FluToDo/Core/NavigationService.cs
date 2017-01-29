using System.Threading.Tasks;
using Xamarin.Forms;

namespace FluToDo.Core
{
    internal class NavigationService : INavigationService
    {
        private NavigationPage navPage;

        public NavigationService(NavigationPage navPage)
        {
            this.navPage = navPage;
        }

        public async Task PushAsync(Page page)
        {
            await this.navPage.PushAsync(page);
        }

        public async Task PopAsync()
        {
            await this.navPage.PopAsync();
        }
    }
}
