using System.Threading.Tasks;

namespace FluToDo.Core
{
    public interface IAlertService
    {
        Task DisplayAlert(string title, string message, string cancel);
    }
}
