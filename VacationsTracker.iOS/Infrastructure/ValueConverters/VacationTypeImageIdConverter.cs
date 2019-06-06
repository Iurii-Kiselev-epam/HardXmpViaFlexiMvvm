using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.iOS.Infrastructure.ValueConverters
{
    class VacationTypeImageIdConverter : ValueConverter<VacationType, string>
    {
        protected override ConversionResult<string> Convert(VacationType value,
            Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case VacationType.Regular:
                    return ConversionResult<string>.SetValue("Icon_Request_Green");
                case VacationType.Sick:
                    return ConversionResult<string>.SetValue("Icon_Request_Plum");
                case VacationType.Exceptional:
                    return ConversionResult<string>.SetValue("Icon_Request_Dark");
                case VacationType.Overtime:
                    return ConversionResult<string>.SetValue("Icon_Request_Blue");
            }
            return ConversionResult<string>.SetValue("Icon_Request_Gray");
        }

        protected override ConversionResult<VacationType> ConvertBack(string value,
            Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<VacationType>.SetValue(VacationType.Undefined);
        }
    }
}