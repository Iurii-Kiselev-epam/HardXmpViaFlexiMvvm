using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.iOS.Infrastructure.ValueConverters
{
    class VacationStatusValueConverter : ValueConverter<VacationStatus, nint>
    {
        protected override ConversionResult<nint> Convert(VacationStatus value,
            Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case VacationStatus.Approved:
                    return ConversionResult<nint>.SetValue(0);
                case VacationStatus.Closed:
                    return ConversionResult<nint>.SetValue(1);
                default:
                    return ConversionResult<nint>.UnsetValue();
            }
        }

        protected override ConversionResult<VacationStatus> ConvertBack(nint value,
            Type targetType, object parameter, CultureInfo culture)
        {
            switch(value)
            {
                case 0:
                    return ConversionResult<VacationStatus>.SetValue(VacationStatus.Approved);
                case 1:
                    return ConversionResult<VacationStatus>.SetValue(VacationStatus.Closed);
                default:
                    return ConversionResult<VacationStatus>.UnsetValue();
            }
        }
    }
}