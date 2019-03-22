using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    {
        private UILabel TitleLabel { get; set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            TitleLabel = new UILabel
            {
                Text = "Login View Controller",
                TextColor = UIColor.Green
            };
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(TitleLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                TitleLabel.AtLeftOf(this),
                TitleLabel.WithSameCenterY(this),
                TitleLabel.AtRightOf(this));
        }
    }
}