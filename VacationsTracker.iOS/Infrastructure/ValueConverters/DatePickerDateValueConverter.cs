using FlexiMvvm.ValueConverters;
using Foundation;
using System;
using System.Globalization;
using VacationsTracker.iOS.Infrastructure.Extensions;

namespace VacationsTracker.iOS.Infrastructure.ValueConverters
{
    public class DatePickerDateValueConverter : ValueConverter<DateTime, NSDate>
    {
        protected override ConversionResult<NSDate> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<NSDate>.SetValue(value.ToNSDate()); // (NSDate)value
        }

        protected override ConversionResult<DateTime> ConvertBack(NSDate value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<DateTime>.SetValue(DateTime.SpecifyKind(((DateTime)value).ToLocalTime().Date, DateTimeKind.Utc));
        }
    }
}