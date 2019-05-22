﻿using Cirrious.FluentLayouts.Touch;
using System;
using UIKit;

namespace VacationsTracker.iOS.Theme
{
    public static class ControlStyleExtensions
    {
        public static UILabel SetErrorTextStyle(this UILabel label, string text = null)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }
            label.Font = AppTheme.Current.Fonts.Message;
            label.TextColor = AppTheme.Current.Colors.DarkRed;
            label.BackgroundColor = AppTheme.Current.Colors.MsgBkgnd;
            label.Lines = 3;
            label.Text = text;
            return label;
        }

        public static UILabel SetLargeCellTextStyle(this UILabel label, string text = null)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }
            label.Font = AppTheme.Current.Fonts.CellLarge;
            label.TextColor = AppTheme.Current.Colors.Bright;
            label.BackgroundColor = UIColor.White;
            label.Lines = 1;
            label.Text = text;
            return label;
        }

        public static UILabel SeCellTextStyle(this UILabel label, string text = null)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }
            label.Font = AppTheme.Current.Fonts.Cell;
            label.TextColor = AppTheme.Current.Colors.PrimaryDark;
            label.BackgroundColor = UIColor.White;
            label.Lines = 1;
            label.Text = text;
            return label;
        }

        public static UITextField SetTextFieldStyle(this UITextField textField, string placeHolder = null)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(nameof(textField));
            }
            textField.Font = AppTheme.Current.Fonts.Input1;
            textField.BackgroundColor = UIColor.White;
            textField.Placeholder = placeHolder;
            textField.TintColor = AppTheme.Current.Colors.TextHint;
            return textField;
        }

        public static UIButton SetButtonStyle(this UIButton button, string title = null)
        {
            if (button == null)
            {
                throw new ArgumentNullException(nameof(button));
            }
            button.Font = AppTheme.Current.Fonts.CellLarge;
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.Layer.CornerRadius = 10;
            button.Layer.MasksToBounds = true;
            //button.AddConstraints(button.Height().EqualTo(AppTheme.Current.Dimens.ButtonDefaultHeight));
            button.BackgroundColor = AppTheme.Current.Colors.Bright;
            return button;
        }

        public static UIActivityIndicatorView SetActivityIndicatorStyle(this UIActivityIndicatorView activityIndicator)
        {
            if (activityIndicator == null)
            {
                throw new ArgumentNullException(nameof(activityIndicator));
            }

            activityIndicator.Color = AppTheme.Current.Colors.Bright;
            activityIndicator.AddConstraints(activityIndicator.Height().EqualTo(AppTheme.Current.Dimens.Inset4x));
            activityIndicator.AddConstraints(activityIndicator.Width().EqualTo(AppTheme.Current.Dimens.Inset4x));

            return activityIndicator;
        }
    }
}