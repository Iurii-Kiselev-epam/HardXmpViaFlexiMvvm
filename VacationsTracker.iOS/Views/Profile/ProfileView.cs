using Cirrious.FluentLayouts.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.iOS.Infrastructure.Extensions;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Profile
{
    public class ProfileView : LayoutView
    {
        private UIImageView AvatarImageView { get; set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            AvatarImageView = (new UIImageView()).SetBundleImage("Avatar");
            AvatarImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();
            this
                .AddLayoutSubview(AvatarImageView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                AvatarImageView.AtTopOf(this),
                AvatarImageView.WithSameCenterX(this),
                AvatarImageView.Height().EqualTo(AppTheme.Current.Dimens.MediumAvatarHeight));
        }
    }
}