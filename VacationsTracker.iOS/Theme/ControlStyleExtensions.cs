﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VacationsTracker.iOS.Theme
{
    public static class ControlStyleExtensions
    {
        public static UILabel SetErrorTextStyle(this UILabel label, string text = null)
        {
            label.Font = AppTheme.Current.Fonts.Message;
            label.TextColor = AppTheme.Current.Colors.DarkRed;
            label.BackgroundColor = AppTheme.Current.Colors.MsgBkgnd;
            label.Lines = 3;
            label.Text = text;
            return label;
        }

        public static UITextField SetTextFieldStyle(this UITextField textField, string placeHolder = null)
        {
            textField.Font = AppTheme.Current.Fonts.Input1;
            textField.BackgroundColor = AppTheme.Current.Colors.White;
            textField.Placeholder = placeHolder;
            textField.TintColor = AppTheme.Current.Colors.TextHint;
            return textField;
        }

        public static UIButton SetButtonStyle(this UIButton button, string title = null)
        {
            button.Font = AppTheme.Current.Fonts.CellLarge;
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(AppTheme.Current.Colors.White, UIControlState.Normal);
            button.Layer.CornerRadius = 10;
            button.Layer.MasksToBounds = true;
            //button.AddConstraints(button.Height().EqualTo(AppTheme.Current.Dimens.ButtonDefaultHeight));
            button.BackgroundColor = AppTheme.Current.Colors.Bright;

            return button;
        }
    }
}