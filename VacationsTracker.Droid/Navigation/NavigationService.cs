using Android.Content;
using FlexiMvvm;
using VacationsTracker.Droid.Views;
using VacationsTracker.Droid.Extensions;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using System;
using FlexiMvvm.Views;
using Android.Support.V4.App;
using FlexiMvvm.ViewModels;
using VacationsTracker.Droid.Views.Login;
using VacationsTracker.Droid.Views.Home;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Droid.Views.Profile;

namespace VacationsTracker.Droid.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateTo<TFrom, TTo, TFromViewModel>(TFromViewModel fromviewModel,
            bool cleanHistory = false,
            Action<Intent> fnTuneAction = null)
            where TFromViewModel : class, IViewModel
            where TFrom : FragmentActivity, INavigationView<TFromViewModel>
            where TTo : FragmentActivity
        {
            var activity = GetActivity<TFrom, TFromViewModel>(fromviewModel);
            var intent = new Intent(activity, typeof(TTo));
            if (cleanHistory)
            {
                intent.CleanBackStack();
            }
            fnTuneAction?.Invoke(intent);
            activity.NotNull().StartActivity(intent);
        }

        public void NavigateToLogin(EntryViewModel fromViewModel) =>
            NavigateTo<SplashScreenActivity, LoginActivity, EntryViewModel>(fromViewModel,
                cleanHistory: true);

        public void NavigateToMainList(LoginViewModel fromViewModel) =>
            NavigateTo<LoginActivity, MainListActivity, LoginViewModel>(fromViewModel,
                cleanHistory: true);

        public void NavigateToProfile(MainListViewModel fromViewModel) =>
            NavigateTo<MainListActivity, ProfileActivity, MainListViewModel>(
                fromViewModel,
                false,
                intent =>
                {
                    // TODO: tune fromViewModel.Filter
                    // ...
                });
    }
}