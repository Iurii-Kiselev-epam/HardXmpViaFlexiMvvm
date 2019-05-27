using FlexiMvvm.Collections;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Core.Presentation.ViewModels.Request
{
    public class EditableVacationRequestViewModel : VacationRequestViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;
        private bool _progressVisible;
        private bool _pickerVisible;
        private bool _isEndEditMode;
        private DateTime _minValue;
        private DateTime _maxValue;

        /// <summary>
        /// ctor() for details view.
        /// </summary>
        /// <param name="navigationService">navigation service</param>
        /// <param name="xmpProxy">xmp service proxy</param>
        public EditableVacationRequestViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy)
            : base()
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _xmpProxy = xmpProxy ?? throw new ArgumentNullException(nameof(xmpProxy));

            AllValueableVacationTypes = new ObservableCollection<VacationTypeParameters>();
            AllValueableVacationTypes.AddRange(VacationTypeExtensions
                .GetAllValueableTypes()
                .Select(vt => new VacationTypeParameters
                {
                    VacationReason = vt
                }));
            VacationTypesCount = AllValueableVacationTypes.Count;
        }

        public DateTime MinValue
        {
            get => _minValue;
            set => SetValue(ref _minValue, value);
        }

        public DateTime MaxValue
        {
            get => _maxValue;
            set => SetValue(ref _maxValue, value);
        }

        /// <summary>
        /// Date picker bounded to end date (or to start date);
        /// </summary>
        public bool IsEndEditMode
        {
            get => _isEndEditMode;
            set
            {
                SetValue(ref _isEndEditMode, value);
                RaisePropertyChanged(nameof(PickerValue));
            }
        }

        public bool ProgressVisible
        {
            get => _progressVisible;
            set => SetValue(ref _progressVisible, value);
        }

        public bool PickerVisible
        {
            get => _pickerVisible;
            set => SetValue(ref _pickerVisible, value);
        }

        public DateTime PickerValue
        {
            get => IsEndEditMode ? End : Start;
            set
            {
                if (IsEndEditMode)
                {
                    End = value;
                    if (Start > End)
                    {
                        Start = End;
                    }
                }
                else
                {
                    Start = value;
                    if (End < Start)
                    {
                        End = Start;
                    }
                }
                RaisePropertyChanged(nameof(PickerValue));
            }
        }

        public ObservableCollection<VacationTypeParameters> AllValueableVacationTypes { get; }

        public int VacationTypesCount { get; }

        public ICommand SaveCommand => CommandProvider.GetForAsync(Save);

        public ICommand StartPickerCommand => CommandProvider.Get(StartPicker);
        public ICommand EndPickerCommand => CommandProvider.Get(EndPicker);

        public override async Task InitializeAsync(VacationRequestParameters parameters)
        {
            await base.InitializeAsync(parameters);

            if (parameters.RequestId != Guid.Empty)
            {
                ProgressVisible = true;

                // get request from server
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
                finally
                {
                    ProgressVisible = false;
                }
            }
        }

        private async Task Save()
        {
            ProgressVisible = true;
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
            finally
            {
                ProgressVisible = false;
            }
        }

        private void StartPicker()
        {
            PickerVisible = true;
            IsEndEditMode = false;

            PickerValue = Start;
            MinValue = PickerValue.AddYears(-1);
            MaxValue = PickerValue.AddYears(1);
        }

        private void EndPicker()
        {
            PickerVisible = true;
            IsEndEditMode = true;

            PickerValue = End;
            MinValue = Start;
            MaxValue = PickerValue.AddYears(1);
        }
    }
}
