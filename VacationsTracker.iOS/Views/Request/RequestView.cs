using Cirrious.FluentLayouts.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Request
{
    public class RequestView : LayoutView
    {
        public UIView VacationTypesPagerView { get; private set; }

        public UIPageControl PageControl { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            VacationTypesPagerView = new UIView
            {
                BackgroundColor = UIColor.White
            };

            PageControl = new UIPageControl().SetPageControlStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this
                .AddLayoutSubview(VacationTypesPagerView)
                .AddLayoutSubview(PageControl);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationTypesPagerView.AtTopOf(this),
                VacationTypesPagerView.AtLeftOf(this),
                VacationTypesPagerView.AtRightOf(this),
                VacationTypesPagerView.Height().EqualTo(AppTheme.Current.Dimens.PagerDefaultHeight));

            this.AddConstraints(
                PageControl.WithSameCenterX(this),
                PageControl.AtLeftOf(this),
                PageControl.AtRightOf(this),
                PageControl.Below(VacationTypesPagerView));
        }
    }
}