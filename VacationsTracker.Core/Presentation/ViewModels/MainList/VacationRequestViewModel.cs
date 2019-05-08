using FlexiMvvm.Collections;
using FlexiMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class VacationRequestViewModel : ViewModel<VacationRequestParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;

        private Guid _id;
        private DateTime _start;
        private DateTime _end;
        private VacationType _vacationType;
        private VacationStatus _vacationStatus;
        private string _createdBy;
        private DateTime _created;
        private ObservableCollection<VacationTypeParameters> _valuableParameters;

        /// <summary>
        /// ctor() for details view.
        /// </summary>
        /// <param name="navigationService">navigation service</param>
        /// <param name="xmpProxy">xmp service proxy</param>
        public VacationRequestViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _xmpProxy = xmpProxy ?? throw new ArgumentNullException(nameof(xmpProxy));

            SetDefault();

            _valuableParameters = new ObservableCollection<VacationTypeParameters>();
            _valuableParameters.AddRange(VacationTypeExtensions
                .GetAllValueableTypes()
                .Select(vt => new VacationTypeParameters
                {
                    VacationReason = vt
                }));
        }

        /// <summary>
        /// ctor() for main list.
        /// </summary>
        /// <param name="vacationRequest">vacation request</param>
        public VacationRequestViewModel(VacationRequest vacationRequest) =>
            GetDataFrom(vacationRequest);

        public ObservableCollection<VacationTypeParameters> AllValueableVacationTypes
        {
            get => _valuableParameters;
        }

        public Guid Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        public DateTime Start
        {
            get => _start;
            set => SetValue(ref _start, value);
        }

        public string ShortStartMonth => GetAbbreviatedEnUsMonthName(Start);

        public string ShortStart => $"{ShortStartMonth} {Start.Day}";

        public DateTime End
        {
            get => _end;
            set => SetValue(ref _end, value);
        }

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

        public ICommand SaveCommand => CommandProvider.GetForAsync(Save);

        private async Task Save()
        {
            try
            {
                var vacationRequest = ToVacationRequest();
                await _xmpProxy.VtsVacationUpsertAsync(vacationRequest);

                // TODO: if operation suceeded
                // navigate to main list
                // ...
            }
            catch (AuthenticationException authExc)
            {
                // TODO: use authExc to log error
                //ErrorMessage = UserConstants.Errors.AuthErrorMessage;
            }
            catch (CommunicationException cmnExc)
            {
                // TODO: use cmnExc to log error
                //ErrorMessage = UserConstants.Errors.CommunicationErrorMessage;
            }
            catch (Exception ex)
            {
                // TODO: use ex to log error
                //ErrorMessage = UserConstants.Errors.UnexpectedErrorMessage;
            }
        }

        public override async Task InitializeAsync(VacationRequestParameters parameters)
        {
            await base.InitializeAsync(parameters);

            if (parameters.RequestId == Guid.Empty)
            {
                SetDefault(createNewGuid: true);
            }
            else
            {
                // TODO: get request from server
                try
                {
                    var result = await _xmpProxy.VtsVacationGetByIdAsync(parameters.RequestId.ToString());
                    GetDataFrom(result.Result);
                }
                catch (AuthenticationException authExc)
                {
                    // TODO: use authExc to log error
                    //ErrorMessage = UserConstants.Errors.AuthErrorMessage;
                }
                catch (CommunicationException cmnExc)
                {
                    // TODO: use cmnExc to log error
                    //ErrorMessage = UserConstants.Errors.CommunicationErrorMessage;
                }
                catch (Exception ex)
                {
                    // TODO: use ex to log error
                    //ErrorMessage = UserConstants.Errors.UnexpectedErrorMessage;
                }
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
