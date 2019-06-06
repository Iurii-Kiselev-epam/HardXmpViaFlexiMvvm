using Foundation;
using System;

namespace VacationsTracker.iOS.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static NSDate ToNSDate(this DateTime date)
        {
            var calendar = NSCalendar.CurrentCalendar;
            var components = new NSDateComponents
            {
                Day = date.Day,
                Month = date.Month,
                Year = date.Year,
                Minute = date.Minute,
                Hour = date.Hour
            };
            return calendar.DateFromComponents(components);
        }
    }
}