using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToLogin(EntryViewModel fromViewModel);
        void NavigateToMainList(LoginViewModel fromViewModel);
        void NavigateToProfile(MainListViewModel fromViewModel);
    }
}
