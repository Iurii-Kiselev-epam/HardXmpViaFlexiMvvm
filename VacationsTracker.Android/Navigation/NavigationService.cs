using Android.Content;
using FlexiMvvm;
using VacationsTracker.Droid.Views;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Droid.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var splashScreenActivity = GetActivity<SplashScreenActivity, EntryViewModel>(fromViewModel);
            var loginIntent = new Intent(splashScreenActivity, typeof(LoginActivity));
            splashScreenActivity.NotNull().StartActivity(loginIntent);
        }

        public void NavigateToMainList(LoginViewModel fromViewModel)
        {
            var loginActivity = GetActivity<LoginActivity, LoginViewModel>(fromViewModel);
            var mainListIntent = new Intent(loginActivity, typeof(MainListActivity));
            loginActivity.NotNull().StartActivity(mainListIntent);
        }
    }
}