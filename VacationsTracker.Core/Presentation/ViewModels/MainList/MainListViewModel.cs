using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using FlexiMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class MainListViewModel : ViewModel<RequestFilterParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;
        private readonly IOperationFactory _operationFactory;
        private bool _progressVisible;
        private RequestFilters _filter;
        private bool _updating;

        public MainListViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy,
            IOperationFactory operationFactory)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _xmpProxy = xmpProxy ?? throw new ArgumentNullException(nameof(xmpProxy));
            _operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));

            ProgressVisible = true;
            VacationRequests = new ObservableCollection<VacationRequestViewModel>();
        }

        public bool ProgressVisible
        {
            get => _progressVisible;
            set
            {
                SetValue(ref _progressVisible, value);
                RaisePropertyChanged(nameof(IsUIVisible));
            }
        }

        public bool IsUIVisible
        {
            get => !ProgressVisible;
        }

        public RequestFilters Filter
        {
            get => _filter;
            set
            {
                SetValue(ref _filter, value);
                RaisePropertyChanged(nameof(UIFilter));
            }
        }

        public string UIFilter
        {
            get => Filter.GetUiName();
        }

        public ObservableCollection<VacationRequestViewModel> VacationRequests
        {
            get;
        }

        public override void Initialize(RequestFilterParameters parameters)
        {
            base.Initialize(parameters);
            Filter = parameters.Filter;
        }

        public Command<VacationRequestViewModel> OpenVacationDetailsCommand =>
            CommandProvider.Get<VacationRequestViewModel>(OpenVacationDetails);

        public ICommand NewRequestCommand => CommandProvider.Get(OnNewRequest);

        public ICommand OpenProfileCommand => CommandProvider.Get(OpenProfile);

        public ICommand UpdateCommand => CommandProvider.GetForAsync(UpdateAsync, () => !_updating);

        private async Task UpdateAsync()
        {
            if (_updating)
            {
                return;
            }

            try
            {
                _updating = true;

                VacationRequests.Clear();
                var vacations = await GetRequestsAsync();
                VacationRequests.AddRange(vacations);
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
                _updating = false;
            }
        }

        private void OpenVacationDetails(VacationRequestViewModel itemViewModel)
        {
            if (itemViewModel == null)
            {
                throw new ArgumentNullException(nameof(itemViewModel));
            }

            DoOpenRequest(itemViewModel.Id);
        }

        private void OpenProfile()
        {
            ProgressVisible = true;
            _navigationService.NavigateToProfile(this,
                new RequestFilterParameters
                {
                    Filter = Filter
                });
        }

        private void OnNewRequest() => DoOpenRequest(Guid.Empty);

        private void DoOpenRequest(Guid id)
        {
            ProgressVisible = true;
            _navigationService.NavigateToRequest(this,
                new VacationRequestParameters
                {
                    RequestId = id
                });
        }

        private async Task<IEnumerable<VacationRequestViewModel>> GetRequestsAsync()
        {
            var listResult = await _xmpProxy.GetRequestsAsync(Filter);
            return listResult
                .Select(v => new VacationRequestViewModel(v))
                .OrderByDescending(v => v.Start);
        }
    }
}
