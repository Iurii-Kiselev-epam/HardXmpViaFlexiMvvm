using System.Threading.Tasks;

namespace VacationsTracker.Core.Infrastructure
{
    public interface IDialogService
    {
        void ShowAlert(string title, string message);

        Task<bool> ShowMessageBox(string title, string message);
    }
}
