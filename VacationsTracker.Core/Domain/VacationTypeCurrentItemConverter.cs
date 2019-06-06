using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Core.Domain
{
    public class VacationTypeCurrentItemConverter : ValueConverter<VacationType, int>
    {
        protected override ConversionResult<int> Convert(VacationType value,
            Type targetType, object parameter, CultureInfo culture) =>
            ConversionResult<int>.SetValue(value.VacationTypeToIndex());

        protected override ConversionResult<VacationType> ConvertBack(int value,
            Type targetType, object parameter, CultureInfo culture) =>
             ConversionResult<VacationType>.SetValue(value.VacationTypeFromIndex());
    }
}
