using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Droid.ValueConverters
{
    class VacationStatusValueConverter : ValueConverter<VacationStatus, int>
    {
        protected override ConversionResult<int> Convert(VacationStatus value,
            Type targetType, object parameter, CultureInfo culture)
        {
            if (value == VacationStatus.Approved)
            {
                return ConversionResult<int>.SetValue(Resource.Id.approved_status_radio_button);
            }
            else if (value == VacationStatus.Closed)
            {
                return ConversionResult<int>.SetValue(Resource.Id.closed_status_radio_button);
            }

            return ConversionResult<int>.UnsetValue();
        }

        protected override ConversionResult<VacationStatus> ConvertBack(int value,
            Type targetType, object parameter, CultureInfo culture)
        {
            if (value == Resource.Id.approved_status_radio_button)
            {
                return ConversionResult<VacationStatus>.SetValue(VacationStatus.Approved);
            }
            else if (value == Resource.Id.closed_status_radio_button)
            {
                return ConversionResult<VacationStatus>.SetValue(VacationStatus.Closed);
            }

            return ConversionResult<VacationStatus>.UnsetValue();
        }
    }
}