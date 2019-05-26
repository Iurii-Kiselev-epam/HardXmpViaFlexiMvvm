using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Request
{
    public class RequestView : ScrollableLayoutView
    {
        public UIView VacationTypesPagerView { get; private set; }

        public UIPageControl PageControl { get; private set; }

        public UIView FirstSplitter { get; private set; }

        public UIControl StartControl { get; private set; }

        public UIControl EndControl { get; private set; }

        public UIView SecondSplitter { get; private set; }

        public UILabel StartDayLabel { get; private set; }

        public UILabel StartMonthLabel { get; private set; }

        public UILabel StartYearLabel { get; private set; }

        public UILabel EndDayLabel { get; private set; }

        public UILabel EndMonthLabel { get; private set; }

        public UILabel EndYearLabel { get; private set; }

        public UISegmentedControl VacationStatusSelector { get; private set; }

        public UIDatePicker DatePicker { get; private set; }

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

            FirstSplitter = new UIView().SetSplitterStyle();

            StartControl = new UIControl
            {
                BackgroundColor = UIColor.Clear
            };

            StartDayLabel = new UILabel().SetDayTextStyle();
            StartMonthLabel = new UILabel().SetMonthTextStyle();
            StartYearLabel = new UILabel().SetYearTextStyle();

            EndControl = new UIControl
            {
                BackgroundColor = UIColor.Clear
            };

            EndDayLabel = new UILabel().SetDayTextStyle(isEnd: true);
            EndMonthLabel = new UILabel().SetMonthTextStyle(isEnd: true);
            EndYearLabel = new UILabel().SetYearTextStyle(isEnd: true);

            SecondSplitter = new UIView().SetSplitterStyle();

            VacationStatusSelector = new UISegmentedControl(
                Strings.VacationStatus_Approved,
                Strings.VacationStatus_Closed).SetSegmentedControlStyle();

            DatePicker = new UIDatePicker().SetDatePickerStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            ContentView
                .AddLayoutSubview(VacationTypesPagerView)
                .AddLayoutSubview(PageControl)
                .AddLayoutSubview(FirstSplitter)
                .AddLayoutSubview(StartControl)
                .AddLayoutSubview(StartDayLabel)
                .AddLayoutSubview(StartMonthLabel)
                .AddLayoutSubview(StartYearLabel)
                .AddLayoutSubview(EndControl)
                .AddLayoutSubview(EndDayLabel)
                .AddLayoutSubview(EndMonthLabel)
                .AddLayoutSubview(EndYearLabel)
                .AddLayoutSubview(SecondSplitter)
                .AddLayoutSubview(VacationStatusSelector)
                .AddLayoutSubview(DatePicker);
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
                FirstSplitter.Below(PageControl, AppTheme.Current.Dimens.Inset1x),
                FirstSplitter.AtLeftOf(ContentView),
                FirstSplitter.AtRightOf(ContentView));

            ContentView.AddConstraints(
                StartControl.Below(FirstSplitter),
                StartControl.AtLeftOf(ContentView),
                StartControl.ToLeftOfCenterOf(ContentView),
                StartControl.Height().EqualTo(AppTheme.Current.Dimens.Inset8x));

            ContentView.AddConstraints(
                EndControl.AtTopOf(StartControl),
                EndControl.ToRightOf(StartControl),
                EndControl.AtRightOf(ContentView),
                EndControl.AtBottomOf(StartControl));

            ContentView.AddConstraints(
                StartDayLabel.AtLeftOf(StartControl, AppTheme.Current.Dimens.Inset4x),
                StartDayLabel.AtTopOf(StartControl, AppTheme.Current.Dimens.Inset1x),
                StartDayLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset6x),
                StartDayLabel.Width().EqualTo(AppTheme.Current.Dimens.Inset6x));

            ContentView.AddConstraints(
                StartMonthLabel.ToRightOf(StartDayLabel, AppTheme.Current.Dimens.Inset1x),
                StartMonthLabel.AtTopOf(StartDayLabel),
                StartMonthLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset3x),
                StartMonthLabel.AtRightOf(StartControl));

            ContentView.AddConstraints(
                StartYearLabel.ToRightOf(StartDayLabel, AppTheme.Current.Dimens.Inset2x),
                StartYearLabel.AtBottomOf(StartDayLabel),
                StartYearLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset2x),
                StartYearLabel.AtRightOf(StartControl));

            ContentView.AddConstraints(
                EndDayLabel.AtLeftOf(EndControl, AppTheme.Current.Dimens.Inset4x),
                EndDayLabel.AtTopOf(EndControl, AppTheme.Current.Dimens.Inset1x),
                EndDayLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset6x),
                EndDayLabel.Width().EqualTo(AppTheme.Current.Dimens.Inset6x));

            ContentView.AddConstraints(
                EndMonthLabel.ToRightOf(EndDayLabel, AppTheme.Current.Dimens.Inset1x),
                EndMonthLabel.AtTopOf(EndDayLabel),
                EndMonthLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset3x),
                EndMonthLabel.AtRightOf(EndControl));

            ContentView.AddConstraints(
                EndYearLabel.ToRightOf(EndDayLabel, AppTheme.Current.Dimens.Inset2x),
                EndYearLabel.AtBottomOf(EndDayLabel),
                EndYearLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset2x),
                EndYearLabel.AtRightOf(EndControl));

            ContentView.AddConstraints(
                SecondSplitter.Below(StartControl),
                SecondSplitter.AtLeftOf(ContentView),
                SecondSplitter.AtRightOf(ContentView));

            ContentView.AddConstraints(
                VacationStatusSelector.WithSameCenterX(ContentView),
                VacationStatusSelector.Below(SecondSplitter, AppTheme.Current.Dimens.Inset4x),
                VacationStatusSelector.Height().EqualTo(AppTheme.Current.Dimens.Inset4x));

            ContentView.AddConstraints(
                DatePicker.AtLeftOf(ContentView),
                DatePicker.AtRightOf(ContentView),
                DatePicker.AtBottomOf(ContentView));
        }
    }
}