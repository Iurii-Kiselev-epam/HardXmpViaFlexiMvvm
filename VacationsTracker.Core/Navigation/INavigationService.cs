using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Core.Presentation.ViewModels.Profile;

namespace VacationsTracker.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToLogin(EntryViewModel fromViewModel);
        void NavigateToMainList(LoginViewModel fromViewModel);
        void NavigateToProfile(MainListViewModel fromViewModel, RequestFilterParameters parameters);
        void NavigateToMainList(ProfileViewModel fromViewModel, RequestFilterParameters parameters);
    }
}
