using FlexiMvvm.ViewModels;
using System;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels.Request
{
    public class DateTimeViewModel : ViewModel
    {
        private DateTime _date;
        private readonly Action<DateTime> _updateAction;

        public DateTimeViewModel(DateTime date, Action<DateTime> updateAction)
        {
            _date = date;
            _updateAction = updateAction ?? throw new ArgumentNullException(nameof(updateAction));
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                SetValue(ref _date, value);
                RaisePropertyChanged(nameof(Day));
                RaisePropertyChanged(nameof(ShortMonth));
                RaisePropertyChanged(nameof(Year));
                _updateAction(_date);
            }
        }

        public string Year => $"{Date.Year}";

        public string Day => $"{Date.Day}";

        public string ShortMonth =>
            Date.GetAbbreviatedEnUsMonthName();
    }
}
