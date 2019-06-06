using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using System;
using UIKit;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Profile
{
    public class RequestFilterView : LayoutView
    {
        public static nfloat Height { get; } = AppTheme.Current.Dimens.TableViewRowDefaultHeight;

        public UILabel RequestUiFilterLabel { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            LayoutMargins = new UIEdgeInsets(
                0, AppTheme.Current.Dimens.Inset1x,
                0, AppTheme.Current.Dimens.Inset1x);

            BackgroundColor = UIColor.White;

            RequestUiFilterLabel = new UILabel().SeCellTextStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();
            this.AddLayoutSubview(RequestUiFilterLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                RequestUiFilterLabel.AtRightOf(this, AppTheme.Current.Dimens.Inset2x),
                RequestUiFilterLabel.WithSameCenterY(this),
                RequestUiFilterLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset4x));
        }
    }
}