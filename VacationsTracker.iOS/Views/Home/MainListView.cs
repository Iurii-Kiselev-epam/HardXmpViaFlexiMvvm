using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Infrastructure.Extensions;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Home
{
    public class MainListView : LayoutView
    {
        protected override void SetupSubviews()
        {
            base.SetupSubviews();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            //this
            //    .AddLayoutSubview(BackgroundImageView)
            //    .AddLayoutSubview(ErrorTextLabel)
            //    .AddLayoutSubview(LoginTextField)
            //    .AddLayoutSubview(PasswordTextField)
            //    .AddLayoutSubview(SignInButton);

            //this.SendSubviewToBack(BackgroundImageView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            //this.AddConstraints(
            //    BackgroundImageView.WithSameHeight(this),
            //    BackgroundImageView.WithSameWidth(this),
            //    BackgroundImageView.AtLeftOf(this),
            //    BackgroundImageView.AtTopOf(this));

            //this.AddConstraints(
            //    ErrorTextLabel.WithSameCenterX(this),
            //    ErrorTextLabel.AtTopOf(this, AppTheme.Current.Dimens.Inset8x),
            //    ErrorTextLabel.AtLeftOf(this, AppTheme.Current.Dimens.Inset4x),
            //    ErrorTextLabel.AtRightOf(this, AppTheme.Current.Dimens.Inset4x));

            //this.AddConstraints(
            //    LoginTextField.Below(ErrorTextLabel, AppTheme.Current.Dimens.Inset2x),
            //    LoginTextField.WithSameCenterX(this),
            //    LoginTextField.AtLeftOf(this, AppTheme.Current.Dimens.Inset4x),
            //    LoginTextField.AtRightOf(this, AppTheme.Current.Dimens.Inset4x));

            //this.AddConstraints(
            //    PasswordTextField.Below(LoginTextField, AppTheme.Current.Dimens.Inset2x),
            //    PasswordTextField.WithSameCenterX(this),
            //    PasswordTextField.AtLeftOf(this, AppTheme.Current.Dimens.Inset4x),
            //    PasswordTextField.AtRightOf(this, AppTheme.Current.Dimens.Inset4x));

            //this.AddConstraints(
            //    SignInButton.Below(PasswordTextField, AppTheme.Current.Dimens.Inset2x),
            //    SignInButton.WithSameCenterX(this),
            //    SignInButton.AtLeftOf(this, AppTheme.Current.Dimens.Inset7x),
            //    SignInButton.AtRightOf(this, AppTheme.Current.Dimens.Inset7x));
        }
    }
}