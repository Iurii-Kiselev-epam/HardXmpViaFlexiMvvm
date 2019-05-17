using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginViewController : BindableViewController<LoginViewModel>
    {
        public new LoginView View
        {
            get => (LoginView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView() =>
            View = new LoginView();

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.ErrorTextLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.ErrorMessage);
            bindingSet.Bind(View.ErrorTextLabel)
                .For(v => v.HiddenBinding())
                .To(vm => vm.ErrorMessageVisible)
                .WithConversion<InvertValueConverter>();

            bindingSet.Bind(View.LoginTextField)
                .For(v => v.TextAndEditingDidEndBinding())
                .To(vm => vm.Login);

            bindingSet.Bind(View.PasswordTextField)
                .For(v => v.TextAndEditingDidEndBinding())
                .To(vm => vm.Password);

            bindingSet.Bind(View.SignInButton)
                  .For(v => v.TouchUpInsideBinding())
                  .To(vm => vm.SignInCommand);
            bindingSet.Bind(View.SignInButton)
                .For(v => v.HiddenBinding())
                .To(vm => vm.SignInVisible)
                .WithConversion<InvertValueConverter>();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Title = string.Empty;
            NavigationController.NavigationBarHidden = true;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            HideKeyboard();
        }

        private void HideKeyboard() =>
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
    }
}