using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Infrastructure.Extensions;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Home
{
    public class MainListView : LayoutView
    {
        public UICollectionView VacationsView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.MsgBkgnd;

            var collectionLayout = new UICollectionViewFlowLayout
            {
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
                MinimumLineSpacing = AppTheme.Current.Dimens.LineSpacing,
                MinimumInteritemSpacing = AppTheme.Current.Dimens.LineSpacing,
                SectionInset = UIEdgeInsets.Zero,
                ItemSize = new CGSize((float)UIScreen.MainScreen.Bounds.Size.Width,
                    (float)AppTheme.Current.Dimens.MediumCellDefaultSize)
            };

            VacationsView = new UICollectionView(CGRect.Empty, collectionLayout)
            {
                BackgroundColor = AppTheme.Current.Colors.MsgBkgnd
            };
            VacationsView.RegisterClassForCell(typeof(VacationRequestViewCell), VacationRequestViewCell.CellId);
            //VacationsView.RegisterClassForSupplementaryView(
            //    typeof(LoadNextPageFooterViewCell),
            //    UICollectionElementKindSection.Footer,
            //    LoadNextPageFooterViewCell.CellId);
            VacationsView.ShowsVerticalScrollIndicator = true;
            VacationsView.AllowsSelection = true;
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