using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.ValueConverters;
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

            bindingSet.Bind(ViewHolder.ErrorTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.ErrorMessage);
            bindingSet.Bind(ViewHolder.ErrorTextView)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.ErrorMessageVisible)
                .WithConversion<VisibleInvisibleValueConverter>();

            bindingSet.Bind(ViewHolder.LoginEditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Login);

            bindingSet.Bind(ViewHolder.PasswordEditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Password);

            bindingSet.Bind(ViewHolder.SignInButton)
              .For(v => v.ClickBinding())
              .To(vm => vm.SignInCommand);
            bindingSet.Bind(ViewHolder.SignInButton)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.SignInVisible)
                .WithConversion<VisibleInvisibleValueConverter>();

            bindingSet.Bind(ViewHolder.ProgressBarWidget)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.ProgressVisible)
                .WithConversion<VisibleInvisibleValueConverter>();
        }
    }
}