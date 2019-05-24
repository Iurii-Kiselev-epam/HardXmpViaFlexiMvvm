﻿using FlexiMvvm.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.iOS.Infrastructure.ValueConverters
{
    public class VacationTypeCurrentItemNintConverter : ValueConverter<VacationType, nint>
    {
        private static readonly IList<VacationType> _allValueableTypes;

        /// <summary>
        /// cctor() to cache valueable vacation types.
        /// </summary>
        static VacationTypeCurrentItemNintConverter()
        {
            _allValueableTypes = VacationTypeExtensions
                .GetAllValueableTypes().
                ToList();
        }

        protected override ConversionResult<nint> Convert(VacationType value,
            Type targetType, object parameter, CultureInfo culture) =>
            ConversionResult<nint>.SetValue((nint)_allValueableTypes.IndexOf(value));

        protected override ConversionResult<VacationType> ConvertBack(nint value,
            Type targetType, object parameter, CultureInfo culture) =>
            (0 <= value && value < _allValueableTypes.Count) ?
                 ConversionResult<VacationType>.SetValue(_allValueableTypes[(int)value])
                 : ConversionResult<VacationType>.SetValue(VacationType.Undefined);
    }
}