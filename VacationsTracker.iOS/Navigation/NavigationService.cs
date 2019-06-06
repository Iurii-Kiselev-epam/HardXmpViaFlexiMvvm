using FlexiMvvm;
using UIKit;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Core.Presentation.ViewModels.Profile;
using VacationsTracker.iOS.Views;
using VacationsTracker.iOS.Views.Home;
using VacationsTracker.iOS.Views.Login;
using VacationsTracker.iOS.Views.Profile;
using VacationsTracker.iOS.Views.Request;

namespace VacationsTracker.iOS.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var rootViewController = GetViewController<RootNavigationController, EntryViewModel>(fromViewModel);
            rootViewController.NotNull().PushViewController(
                new LoginViewController(), false);
        }

        public void NavigateToMainList(LoginViewModel fromViewModel)
        {
            var loginViewController = GetViewController<LoginViewController, LoginViewModel>(fromViewModel);
            loginViewController.NavigationController.NotNull().SetViewControllers(
                new UIViewController[] {
                    new MainListViewControlller(new RequestFilterParameters
                    {
                        Filter = RequestFilters.All
                    })
                }, false);
        }

        public void NavigateToMainList(ProfileViewModel fromViewModel, RequestFilterParameters parameters)
        {
            var profileViewController = GetViewController<ProfileViewController, ProfileViewModel>(fromViewModel);
            profileViewController.NavigationController.NotNull().PushViewController(
                new MainListViewControlller(parameters), false);
        }

        public void NavigateToProfile(MainListViewModel fromViewModel, RequestFilterParameters parameters)
        {
            var mainListViewController = GetViewController<MainListViewControlller, MainListViewModel>(fromViewModel);
            mainListViewController.NavigationController.NotNull().PushViewController(
                new ProfileViewController(parameters), false);
        }

        public void NavigateToRequest(MainListViewModel fromViewModel, VacationRequestParameters parameters)
        {
            var mainListViewController = GetViewController<MainListViewControlller, MainListViewModel>(fromViewModel);
            mainListViewController.NavigationController.NotNull().PushViewController(
                new RequestViewController(parameters), false);
        }
    }
}