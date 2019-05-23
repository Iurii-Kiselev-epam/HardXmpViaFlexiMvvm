using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Infrastructure.Extensions;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Profile
{
    public class ProfileView : LayoutView
    {
        private UIView BackgroundBoxView { get; set; }

        private UIImageView AvatarImageView { get; set; }

        private UILabel ProfileNameLabel { get; set; }

        public UITableView FiltersView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.MsgBkgnd; // UIColor.White;

            BackgroundBoxView = new UIView
            {
                BackgroundColor = UIColor.White
            };

            AvatarImageView = new UIImageView().SetBundleImage("Avatar");
            AvatarImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

            ProfileNameLabel = new UILabel().SetLargeCellTextStyle(Strings.Profile_Name);

            FiltersView = new UITableView
            {
                BackgroundColor = AppTheme.Current.Colors.MsgBkgnd,
                TableFooterView = new UIView(),
                EstimatedRowHeight = RequestFilterView.Height,
                KeyboardDismissMode = UIScrollViewKeyboardDismissMode.OnDrag
            };
            FiltersView.RegisterClassForCellReuse(typeof(RequestFilterViewCell),
                RequestFilterViewCell.CellId);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();
            this
                .AddLayoutSubview(BackgroundBoxView)
                .AddLayoutSubview(AvatarImageView)
                .AddLayoutSubview(ProfileNameLabel)
                .AddLayoutSubview(FiltersView);

            SendSubviewToBack(BackgroundBoxView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                AvatarImageView.AtTopOf(this),
                AvatarImageView.WithSameCenterX(this),
                AvatarImageView.Height().EqualTo(AppTheme.Current.Dimens.MediumAvatarHeight));

            this.AddConstraints(
                ProfileNameLabel.Below(AvatarImageView), // , AppTheme.Current.Dimens.Inset2x
                ProfileNameLabel.WithSameCenterX(this),
                ProfileNameLabel.Height().EqualTo(AppTheme.Current.Dimens.Inset6x));

            this.AddConstraints(
                BackgroundBoxView.AtTopOf(this),
                BackgroundBoxView.WithSameWidth(this),
                BackgroundBoxView.ToBottomMargin(ProfileNameLabel));

            this.AddConstraints(
                FiltersView.Below(BackgroundBoxView, AppTheme.Current.Dimens.LineSpacing),
                FiltersView.WithSameWidth(this),
                FiltersView.Height().EqualTo(AppTheme.Current.Dimens.MediumAvatarHeight));
        }
    }
}