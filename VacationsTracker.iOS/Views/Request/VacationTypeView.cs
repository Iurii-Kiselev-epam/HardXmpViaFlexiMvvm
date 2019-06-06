using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Request
{
    public class VacationTypeView : LayoutView
    {
        public UIImageView ImageView { get; private set; }
        public UILabel Label { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            ImageView = new UIImageView
            {
                ContentMode = UIViewContentMode.ScaleAspectFit
            };

            Label = new UILabel().SePagerTextStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this
                .AddLayoutSubview(ImageView)
                .AddLayoutSubview(Label);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ImageView.AtTopOf(this, AppTheme.Current.Dimens.Inset2x),
                ImageView.WithSameCenterX(this),
                ImageView.Height().EqualTo(AppTheme.Current.Dimens.MediumCellDefaultSize));

            this.AddConstraints(
                Label.Below(ImageView),
                Label.WithSameCenterX(this),
                Label.Height().EqualTo(AppTheme.Current.Dimens.Inset6x));
        }
    }
}