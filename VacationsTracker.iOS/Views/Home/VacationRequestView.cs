﻿using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Views;
using System;
using UIKit;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Home
{
    public class VacationRequestView : LayoutView
    {
        public static nfloat Height { get; } = AppTheme.Current.Dimens.TableViewRowDefaultHeight;

        public UIImageView ImageCellView { get; private set; }
        public UILabel DurationRange { get; private set; }
        public UILabel VacationType { get; private set; }
        public UILabel VacationStatus { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            LayoutMargins = new UIEdgeInsets(
                0, AppTheme.Current.Dimens.Inset1x,
                0, AppTheme.Current.Dimens.Inset1x);

            BackgroundColor = UIColor.White;

            ImageCellView = new UIImageView();
            DurationRange = new UILabel().SetLargeCellTextStyle();
            VacationType = new UILabel().SeCellTextStyle();
            VacationStatus = new UILabel().SeCellTextStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(ImageCellView)
                .AddLayoutSubview(DurationRange)
                .AddLayoutSubview(VacationType)
                .AddLayoutSubview(VacationStatus);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                this.Height().NotNull().EqualTo(Height));

            this.AddConstraints(
                ImageCellView.AtLeftOf(this, AppTheme.Current.Dimens.Inset1x),
                ImageCellView.AtTopOf(this, AppTheme.Current.Dimens.Inset1x),
                ImageCellView.AtBottomOf(this),
                ImageCellView.Width().EqualTo(AppTheme.Current.Dimens.MediumCellDefaultSize),
                ImageCellView.Height().EqualTo(AppTheme.Current.Dimens.MediumCellDefaultSize));

            this.AddConstraints(
                DurationRange.AtTopOf(this),
                DurationRange.ToRightOf(ImageCellView, AppTheme.Current.Dimens.Inset1x));

            this.AddConstraints(
                VacationType.AtBottomOf(this),
                VacationType.ToRightOf(ImageCellView, AppTheme.Current.Dimens.Inset2x),
                VacationType.Below(DurationRange, AppTheme.Current.Dimens.Inset1x),
                VacationType.Height().EqualTo(AppTheme.Current.Dimens.Inset3x));

            this.AddConstraints(
                VacationStatus.AtRightOf(this, AppTheme.Current.Dimens.Inset2x),
                VacationStatus.WithSameCenterY(this),
                VacationStatus.Height().EqualTo(AppTheme.Current.Dimens.Inset3x));
        }
    }
}