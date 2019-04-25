using FlexiMvvm;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.iOS.Views;
using VacationsTracker.iOS.Views.Login;

namespace VacationsTracker.iOS.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var rootViewController = GetViewController<RootNavigationController, EntryViewModel>(fromViewModel);
            rootViewController.NotNull().PushViewController(new LoginViewController(), false);
        }

        public void NavigateToMainList(LoginViewModel fromViewModel)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateToProfile(MainListViewModel fromViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}