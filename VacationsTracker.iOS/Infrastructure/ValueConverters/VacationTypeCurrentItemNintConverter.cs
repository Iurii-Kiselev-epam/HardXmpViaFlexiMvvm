using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.iOS.Infrastructure.ValueConverters
{
    public class VacationTypeCurrentItemNintConverter : ValueConverter<VacationType, nint>
    {
        protected override ConversionResult<nint> Convert(VacationType value,
            Type targetType, object parameter, CultureInfo culture) =>
            ConversionResult<nint>.SetValue((nint)value.VacationTypeToIndex());

        protected override ConversionResult<VacationType> ConvertBack(nint value,
            Type targetType, object parameter, CultureInfo culture) =>
                 ConversionResult<VacationType>.SetValue(((int)value).VacationTypeFromIndex());
    }
}