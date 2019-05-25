using Cirrious.FluentLayouts.Touch;
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

        public static UILabel SePagerTextStyle(this UILabel label, string text = null)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }
            label.Font = AppTheme.Current.Fonts.Input1;
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

        public static UIBarButtonItem SetBarButtonItemStyle(this UIBarButtonItem barButtonItem)
        {
            if (barButtonItem == null)
            {
                throw new ArgumentNullException(nameof(barButtonItem));
            }
            barButtonItem.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White,
                Font = AppTheme.Current.Fonts.Title
            }, UIControlState.Normal);
            return barButtonItem;
        }

        public static UIBarButtonItem SetBoldBarButtonItemStyle(this UIBarButtonItem barButtonItem)
        {
            if (barButtonItem == null)
            {
                throw new ArgumentNullException(nameof(barButtonItem));
            }
            barButtonItem.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White,
                Font = AppTheme.Current.Fonts.TitleBold
            }, UIControlState.Normal);
            return barButtonItem;
        }

        public static UIPageControl SetPageControlStyle(this UIPageControl pageControl)
        {
            pageControl.TintColor = AppTheme.Current.Colors.GrayText;
            pageControl.PageIndicatorTintColor = AppTheme.Current.Colors.GrayText;
            pageControl.CurrentPageIndicatorTintColor = AppTheme.Current.Colors.Bright;
            pageControl.CurrentPage = 0;
            pageControl.HidesForSinglePage = true;
            pageControl.BackgroundColor = UIColor.Clear;

            return pageControl;
        }

        public static UISegmentedControl SetSegmentedControlStyle(this UISegmentedControl segmentedControl)
        {
            segmentedControl.TintColor = AppTheme.Current.Colors.DateGreen;
            segmentedControl.BackgroundColor = UIColor.Clear;
            segmentedControl.ControlStyle = UISegmentedControlStyle.Bordered;
            segmentedControl.Layer.BorderColor = AppTheme.Current.Colors.DateGreen.CGColor;
            segmentedControl.Layer.CornerRadius = AppTheme.Current.Dimens.TextPadding;

            segmentedControl.SetTitleTextAttributes(new UITextAttributes
            {
                Font = AppTheme.Current.Fonts.CellLarge,
                TextColor = UIColor.White

            }, UIControlState.Selected);
            segmentedControl.SetTitleTextAttributes(new UITextAttributes
            {
                Font = AppTheme.Current.Fonts.CellLarge,
                TextColor = UIColor.DarkGray
            }, UIControlState.Normal);

            return segmentedControl;
        }
    }
}