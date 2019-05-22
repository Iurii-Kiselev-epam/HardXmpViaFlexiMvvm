using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Home
{
    public class MainListView : LayoutView
    {
        public UITableView VacationsView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.MsgBkgnd;

            VacationsView = new UITableView
            {
                BackgroundColor = AppTheme.Current.Colors.MsgBkgnd,
                TableFooterView = new UIView(),
                EstimatedRowHeight = VacationRequestView.Height,
                KeyboardDismissMode = UIScrollViewKeyboardDismissMode.OnDrag
            };
            VacationsView.RegisterClassForCellReuse(typeof(VacationRequestViewCell),
                VacationRequestViewCell.CellId);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this
                .AddLayoutSubview(VacationsView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationsView.AtLeftOf(this),
                VacationsView.AtTopOf(this),
                VacationsView.WithSameHeight(this),
                VacationsView.WithSameWidth(this));
        }
    }
}