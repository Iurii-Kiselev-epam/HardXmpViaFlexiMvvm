using Cirrious.FluentLayouts.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.iOS.Theme;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.iOS.Views.Request
{
    public class RequestView : ScrollableLayoutView
    {
        public UIView VacationTypesPagerView { get; private set; }

        public UIPageControl PageControl { get; private set; }

        public UISegmentedControl VacationStatusSelector { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;
            ContentView.BackgroundColor = UIColor.White;

            VacationTypesPagerView = new UIView
            {
                BackgroundColor = UIColor.White
            };

            PageControl = new UIPageControl().SetPageControlStyle();

            VacationStatusSelector = new UISegmentedControl(
                Strings.VacationStatus_Approved,
                Strings.VacationStatus_Closed).SetSegmentedControlStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            ContentView
                .AddLayoutSubview(VacationTypesPagerView)
                .AddLayoutSubview(PageControl)
                .AddLayoutSubview(VacationStatusSelector);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            ContentView.AddConstraints(
                VacationTypesPagerView.AtTopOf(ContentView),
                VacationTypesPagerView.AtLeftOf(ContentView),
                VacationTypesPagerView.AtRightOf(ContentView),
                VacationTypesPagerView.Height().EqualTo(AppTheme.Current.Dimens.PagerDefaultHeight));

            ContentView.AddConstraints(
                PageControl.WithSameCenterX(ContentView),
                PageControl.AtLeftOf(ContentView),
                PageControl.AtRightOf(ContentView),
                PageControl.Below(VacationTypesPagerView));

            ContentView.AddConstraints(
                VacationStatusSelector.WithSameCenterX(ContentView),
                VacationStatusSelector.Below(PageControl, AppTheme.Current.Dimens.Inset2x),
                VacationStatusSelector.Height().EqualTo(AppTheme.Current.Dimens.MediumCellDefaultSize));
        }
    }
}