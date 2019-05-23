using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Infrastructure.Extensions;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    {
        private UIImageView BackgroundImageView { get; set; }

        public UILabel ErrorTextLabel { get; private set; }

        public UITextField LoginTextField { get; private set; }

        public UITextField PasswordTextField { get; private set; }

        public UIButton SignInButton { get; private set; }

        public UIActivityIndicatorView ActivityIndicatorView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundImageView = new UIImageView().SetBundleImage("LoginBackground");

            ErrorTextLabel = new UILabel().SetErrorTextStyle();

            LoginTextField = new UITextField().SetTextFieldStyle(Strings.Login_Hint);

            PasswordTextField = new UITextField().SetTextFieldStyle(Strings.Password_Hint);
            PasswordTextField.SecureTextEntry = true;
            PasswordTextField.ReturnKeyType = UIReturnKeyType.Done;

            SignInButton = new UIButton(UIButtonType.System).SetButtonStyle(Strings.Sign_In_Button_Text);

            ActivityIndicatorView = new UIActivityIndicatorView().SetActivityIndicatorStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this
                .AddLayoutSubview(BackgroundImageView)
                .AddLayoutSubview(ErrorTextLabel)
                .AddLayoutSubview(LoginTextField)
                .AddLayoutSubview(PasswordTextField)
                .AddLayoutSubview(SignInButton)
                .AddLayoutSubview(ActivityIndicatorView);

            this.SendSubviewToBack(BackgroundImageView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                BackgroundImageView.FullSizeOf(this));

            this.AddConstraints(
                ErrorTextLabel.WithSameCenterX(this),
                ErrorTextLabel.AtTopOf(this, AppTheme.Current.Dimens.Inset8x),
                ErrorTextLabel.AtLeftOf(this, AppTheme.Current.Dimens.Inset4x),
                ErrorTextLabel.AtRightOf(this, AppTheme.Current.Dimens.Inset4x));

            this.AddConstraints(
                LoginTextField.Below(ErrorTextLabel, AppTheme.Current.Dimens.Inset2x),
                LoginTextField.WithSameCenterX(this),
                LoginTextField.AtLeftOf(this, AppTheme.Current.Dimens.Inset4x),
                LoginTextField.AtRightOf(this, AppTheme.Current.Dimens.Inset4x));

            this.AddConstraints(
                PasswordTextField.Below(LoginTextField, AppTheme.Current.Dimens.Inset2x),
                PasswordTextField.WithSameCenterX(this),
                PasswordTextField.AtLeftOf(this, AppTheme.Current.Dimens.Inset4x),
                PasswordTextField.AtRightOf(this, AppTheme.Current.Dimens.Inset4x));

            this.AddConstraints(
                SignInButton.Below(PasswordTextField, AppTheme.Current.Dimens.Inset2x),
                SignInButton.WithSameCenterX(this),
                SignInButton.AtLeftOf(this, AppTheme.Current.Dimens.Inset7x),
                SignInButton.AtRightOf(this, AppTheme.Current.Dimens.Inset7x));

            this.AddConstraints(
                ActivityIndicatorView.Below(SignInButton, AppTheme.Current.Dimens.Inset2x),
                ActivityIndicatorView.WithSameCenterX(this));
        }
    }
}