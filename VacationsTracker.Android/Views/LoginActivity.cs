using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Android.Views
{
    [Activity(
        Theme = "@style/LoginTheme",
        Label = "LoginActivity",
        NoHistory = true)]
    public class LoginActivity : BindableAppCompatActivity<LoginViewModel>
    {
        private EditText _login;
        private EditText _password;
        private Button _signIn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_login);

            _login = FindViewById<EditText>(Resource.Id.login);
            _password = FindViewById<EditText>(Resource.Id.password);
            _signIn = FindViewById<Button>(Resource.Id.signIn);

            base.OnCreate(savedInstanceState);
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(_login)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Login);

            bindingSet.Bind(_password)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Password);

            bindingSet.Bind(_signIn)
              .For(v => v.ClickBinding())
              .To(vm => vm.SignInCommand);

            ViewModel.LoginFailed += OnLoginFailed; // subscribe on event
        }

        protected override void OnDestroy()
        {
            ViewModel.LoginFailed -= OnLoginFailed; // unsubscribe from event
            base.OnDestroy();
        }

        private void OnLoginFailed(object sender, System.EventArgs e)
        {
            // only for debug aims
            if (string.IsNullOrWhiteSpace(ViewModel.Login)
                || string.IsNullOrWhiteSpace(ViewModel.Password))
            {
                // TODO: include fluent validation
                // ...
            }

            // TODO: show warning message
            var toast =Toast.MakeText(this, // ApplicationContext
                "Please, retry your login and password pair. Check current Caps Lock and input language settings",
                ToastLength.Long);

            // TODO: set color message (ask mentor)
            //toast.View.FindViewById<TextView>(Android.Resource.Id.message).SetTextColor(Color.Red);

            // TODO bind to _login text view
            toast.SetGravity(GravityFlags.Top, 0, 0);

            toast.Show();
        }
    }
}