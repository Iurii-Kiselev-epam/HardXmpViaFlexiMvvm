using FlexiMvvm.ViewModels;
using System;
using System.Globalization;
using System.Threading.Tasks;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class VacationRequestViewModel : ViewModel<VacationRequestParameters>
    {
        private Guid _id;
        private DateTime _start;
        private DateTime _end;
        private VacationType _vacationType;
        private VacationStatus _vacationStatus;
        private string _createdBy;
        private DateTime _created;

        public VacationRequestViewModel()
        {
            SetDefault();
        }

        /// <summary>
        /// ctor() for main list.
        /// </summary>
        /// <param name="vacationRequest">vacation request</param>
        public VacationRequestViewModel(VacationRequest vacationRequest) =>
            GetDataFrom(vacationRequest);

        public Guid Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        public DateTime Start
        {
            get => _start;
            set
            {
                SetValue(ref _start, value);
                RaisePropertyChanged(nameof(StartDay));
                RaisePropertyChanged(nameof(ShortStartMonth));
                RaisePropertyChanged(nameof(StartYear));
                RaisePropertyChanged(nameof(DurationRange));
                RaisePropertyChanged(nameof(ShortStart));
            }
        }

        public string StartYear => $"{Start.Year}";

        public string StartDay => $"{Start.Day}";

        public string ShortStartMonth => GetAbbreviatedEnUsMonthName(Start);

        public string ShortStart => $"{ShortStartMonth} {Start.Day}";

        public DateTime End
        {
            get => _end;
            set
            {
                SetValue(ref _end, value);
                RaisePropertyChanged(nameof(EndDay));
                RaisePropertyChanged(nameof(ShortEndMonth));
                RaisePropertyChanged(nameof(EndYear));
                RaisePropertyChanged(nameof(DurationRange));
                RaisePropertyChanged(nameof(ShortEnd));
            }
        }

        public string EndYear => $"{End.Year}";

        public string EndDay => $"{End.Day}";

        public string ShortEndMonth => GetAbbreviatedEnUsMonthName(End);

        public string ShortEnd => $"{ShortEndMonth} {End.Day}";

        public string DurationRange => $"{ShortStart} - {ShortEnd}";

        public VacationType VacationReason
        {
            get => _vacationType;
            set => SetValue(ref _vacationType, value);
        }

        public string VacationTypeUI
        {
            get => VacationReason.GetVacationTypeUI();
        }

        public VacationStatus VacationStatus
        {
            get => _vacationStatus;
            set => SetValue(ref _vacationStatus, value);
        }

        public string VacationStatusUI => VacationStatus.GetVacationStatusUI();

        public string CreatedBy
        {
            get => _createdBy;
            set => SetValue(ref _createdBy, value);
        }

        public DateTime Created
        {
            get => _created;
            set => SetValue(ref _created, value);
        }

        public void GetDataFrom(VacationRequest vacationRequest)
        {
            if (vacationRequest == null)
            {
                throw new ArgumentNullException(nameof(vacationRequest));
            }

            Id = vacationRequest.Id;
            Start = vacationRequest.Start;
            End = vacationRequest.End;
            VacationReason = vacationRequest.VacationType;
            VacationStatus = vacationRequest.VacationStatus;
            CreatedBy = vacationRequest.CreatedBy;
            Created = vacationRequest.Created;
        }

        public VacationRequest ToVacationRequest() =>
            new VacationRequest
            {
                Id = Id,
                Start = Start,
                End = End,
                VacationType = VacationReason,
                VacationStatus = VacationStatus,
                CreatedBy = CreatedBy,
                Created = Created
            };

        public static implicit operator VacationRequest(VacationRequestViewModel vacRqstVwModel) =>
            vacRqstVwModel.ToVacationRequest();

        public static implicit operator VacationRequestViewModel(VacationRequest vacRqst) =>
            new VacationRequestViewModel(vacRqst);

        public override async Task InitializeAsync(VacationRequestParameters parameters)
        {
            await base.InitializeAsync(parameters);

            if (parameters.RequestId == Guid.Empty)
            {
                SetDefault(createNewGuid: true);
            }
        }

        public static string GetAbbreviatedEnUsMonthName(DateTime dateTime)
        {
            var culture = CultureInfo.GetCultureInfo("en-US");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            return dateTimeInfo.GetAbbreviatedMonthName(dateTime.Month).ToUpper();
        }

        private void SetDefault(bool createNewGuid = false)
        {
            Id = createNewGuid ? Guid.NewGuid() : Guid.Empty;
            Start = End = Created = DateTime.UtcNow;
            VacationReason = VacationType.Regular;
            VacationStatus = VacationStatus.Draft;
            CreatedBy = UserSecrets.Default.Login;
        }
    }
}
