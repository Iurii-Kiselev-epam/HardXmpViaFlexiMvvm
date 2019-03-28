using Android.App;
using Android.OS;
using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Droid.Views
{
    [Activity(
        Theme = "@style/LoginTheme",
        Label = "LoginActivity",
        NoHistory = true)]
    public class LoginActivity : BindableAppCompatActivity<LoginViewModel>
    {
        private const string LoginErrorMessage =
            "Please, retry your login and password pair. Check current Caps Lock and input language settings";

        private LoginActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            ViewHolder = new LoginActivityViewHolder(this);
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            ViewHolder.ErrorTextView.Visibility = ViewStates.Invisible;

            bindingSet.Bind(ViewHolder.ErrorTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.ErrorMessage);

            // TODO: ask mentor how to work with visibility
            // how transform bool to ViewState for platform,
            // is there any converter from bool to view state?
            bindingSet.Bind(ViewHolder.ErrorTextView)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.ErrorMessageVisible ? ViewStates.Visible : ViewStates.Invisible);

            bindingSet.Bind(ViewHolder.LoginEditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Login);

            bindingSet.Bind(ViewHolder.PasswordEditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Password);

            bindingSet.Bind(ViewHolder.SignInButton)
              .For(v => v.ClickBinding())
              .To(vm => vm.SignInCommand);
        }
    }
}