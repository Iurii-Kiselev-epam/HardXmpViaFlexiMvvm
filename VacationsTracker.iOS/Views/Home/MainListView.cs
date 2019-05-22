using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Home
{
    public class MainListView : LayoutView
    {
        public UIActivityIndicatorView ActivityIndicatorView { get; private set; }

        public UITableView VacationsView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.MsgBkgnd;

            ActivityIndicatorView = new UIActivityIndicatorView().SetActivityIndicatorStyle();

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
                .AddLayoutSubview(ActivityIndicatorView)
                .AddLayoutSubview(VacationsView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ActivityIndicatorView.FullSizeOf(this));

            this.AddConstraints(
                VacationsView.FullSizeOf(this));
        }
    }
}