using System.Threading.Tasks;
using Xamarin.Forms;

namespace FluToDo.Core
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task PopAsync();
    }
}
