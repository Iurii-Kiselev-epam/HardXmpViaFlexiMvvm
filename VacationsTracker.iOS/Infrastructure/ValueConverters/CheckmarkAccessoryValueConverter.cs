using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using UIKit;

namespace VacationsTracker.iOS.Infrastructure.ValueConverters
{
    /// <summary>
    /// Copied from BFLA.
    /// </summary>
    public class CheckmarkAccessoryValueConverter : ValueConverter<bool, UITableViewCellAccessory>
    {
        protected override ConversionResult<UITableViewCellAccessory> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<UITableViewCellAccessory>.SetValue(
                value ?
                UITableViewCellAccessory.Checkmark
                : UITableViewCellAccessory.None);
        }
    }
}