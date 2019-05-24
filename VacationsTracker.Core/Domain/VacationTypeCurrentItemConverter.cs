using FlexiMvvm.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Core.Domain
{
    public class VacationTypeCurrentItemConverter : ValueConverter<VacationType, int>
    {
        private static readonly IList<VacationType> _allValueableTypes;

        /// <summary>
        /// cctor() to cache valueable vacation types.
        /// </summary>
        static VacationTypeCurrentItemConverter()
        {
            _allValueableTypes = VacationTypeExtensions
                .GetAllValueableTypes().
                ToList();
        }

        protected override ConversionResult<int> Convert(VacationType value,
            Type targetType, object parameter, CultureInfo culture) =>
            ConversionResult<int>.SetValue(_allValueableTypes.IndexOf(value));

        protected override ConversionResult<VacationType> ConvertBack(int value,
            Type targetType, object parameter, CultureInfo culture) =>
            (0 <= value && value < _allValueableTypes.Count) ?
                 ConversionResult<VacationType>.SetValue(_allValueableTypes[value])
                 : ConversionResult<VacationType>.SetValue(VacationType.Undefined);
    }
}
