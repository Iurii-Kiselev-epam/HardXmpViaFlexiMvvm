using System;
using System.Globalization;

namespace VacationsTracker.Core.Domain
{
    public static class DateTimeExtensions
    {
        public static string GetAbbreviatedEnUsMonthName(this DateTime dateTime)
        {
            var culture = CultureInfo.GetCultureInfo("en-US");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            return dateTimeInfo.GetAbbreviatedMonthName(dateTime.Month).ToUpper();
        }
    }
}
