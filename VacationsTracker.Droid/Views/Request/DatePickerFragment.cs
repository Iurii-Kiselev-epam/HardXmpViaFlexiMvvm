using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace VacationsTracker.Droid.Views.Request
{
    /// <summary>
    /// Copied from BFLA.
    /// </summary>
    public class DatePickerFragment : AppCompatDialogFragment, DatePickerDialog.IOnDateSetListener
    {
        private const string DateArgumentKey = "Date";
        private const string MaxDateArgumentKey = "MaxDate";

        private Action<DateTime> _dateSet;

        public static DatePickerFragment NewInstance(
            DateTime? date,
            DateTime? maxDate,
            Action<DateTime> dateSet)
        {
            var datePickerFragment = new DatePickerFragment();
            var args = new Bundle();
            args.PutLong(DateArgumentKey, date?.Date.Ticks ?? DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc).Ticks);
            args.PutLong(MaxDateArgumentKey, maxDate?.Date.Ticks ?? DateTime.SpecifyKind(DateTime.MaxValue.Date, DateTimeKind.Utc).Ticks);
            datePickerFragment.Arguments = args;
            datePickerFragment._dateSet = dateSet;

            return datePickerFragment;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var date = new DateTime(Arguments.GetLong(DateArgumentKey), DateTimeKind.Utc);
            var maxDate = new DateTime(Arguments.GetLong(MaxDateArgumentKey), DateTimeKind.Utc);
            var dialog = new DatePickerDialog(Activity,
                Resource.Style.CustomDatePickerDialog,
                this, date.Year, date.Month - 1, date.Day);
            dialog.DatePicker.MaxDate = new DateTimeOffset(maxDate).ToUnixTimeMilliseconds();
            dialog.SetTitle(string.Empty);
            //dialog.DatePicker.CalendarViewShown = true;
            //dialog.DatePicker.SpinnersShown = false;
            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            var dt = new DateTime(year, monthOfYear + 1, dayOfMonth, 0, 0, 0, DateTimeKind.Utc);
            _dateSet?.Invoke(dt);
        }
    }
}