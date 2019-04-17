using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Droid.ValueConverters
{
    class VacationTypeDrawableConverter : ValueConverter<VacationType, int>
    {
        protected override ConversionResult<int> Convert(VacationType value,
            Type targetType, object parameter, CultureInfo culture)
        {
            switch(value)
            {
                case VacationType.Regular:
                    return ConversionResult<int>.SetValue(Resource.Drawable.Icon_Request_Green);
                case VacationType.Sick:
                    return ConversionResult<int>.SetValue(Resource.Drawable.Icon_Request_Plum);
                case VacationType.Exceptional:
                    return ConversionResult<int>.SetValue(Resource.Drawable.Icon_Request_Dark);
                case VacationType.Overtime:
                    return ConversionResult<int>.SetValue(Resource.Drawable.Icon_Request_Blue);
            }
            return ConversionResult<int>.SetValue(Resource.Drawable.Icon_Request_Gray);
        }

        protected override ConversionResult<VacationType> ConvertBack(int value,
            Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<VacationType>.SetValue(VacationType.Undefined);
        }
    }
}