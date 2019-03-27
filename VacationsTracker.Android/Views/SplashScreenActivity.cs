using Android.App;
using FlexiMvvm.Views;
using System.Threading.Tasks;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Droid.Views
{
    [Activity(
        Theme = "@style/SplashTheme",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreenActivity : AppCompatActivity<EntryViewModel>
    {
        const int SplashDelayInMS = 1000;

        protected override void OnResume()
        {
            base.OnResume();
            Task.Factory.StartNew(DoStartup);
        }

        public override void OnBackPressed()
        {
            // nothing do to prevent the back button from canceling the startup process
        }

        async void DoStartup() => await Task.Delay(SplashDelayInMS);
    }
}