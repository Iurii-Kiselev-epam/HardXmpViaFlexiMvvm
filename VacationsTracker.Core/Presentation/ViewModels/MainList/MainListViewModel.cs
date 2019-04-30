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
using VacationsTracker.Core.Resources;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class MainListViewModel : ViewModel<RequestFilterParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;
        private readonly IOperationFactory _operationFactory;
        private bool _progressVisible;
        private RequestFilters _filter;

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

        public override async Task InitializeAsync(RequestFilterParameters parameters)
        {
            await base.InitializeAsync(parameters);

            Filter = parameters.Filter;

            try
            {
                var vacations = await GetRequestsAsync();

                VacationRequests.Clear();
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
            ProgressVisible = false;
        }

        public Command<VacationRequestViewModel> OpenVacationDetailsCommand =>
            CommandProvider.Get<VacationRequestViewModel>(OpenVacationDetails);

        public ICommand NewRequestCommand => CommandProvider.GetForAsync(OnNewRequest);

        public ICommand OpenProfileCommand => CommandProvider.Get(OpenProfile);

        private void OpenVacationDetails(VacationRequestViewModel itemViewModel)
        {
            // TODO: navigate to profile
            //_navigationService.NavigateToEventDetails(this, new EventDetailsParameters { EventId = itemViewModel.Id });
        }

        private void OpenProfile()
        {
            // TODO: navigate to details
            //_navigationService.NavigateToEventDetails(this, new EventDetailsParameters { EventId = itemViewModel.Id });
            ProgressVisible = true;
            _navigationService.NavigateToProfile(this);
        }

        private async Task OnNewRequest()
        {
            // TODO: navigate to details with empty id
            //_navigationService.NavigateToEventDetails(this, new EventDetailsParameters { EventId = itemViewModel.Id });
            await Task.CompletedTask;
        }

        private async Task<IEnumerable<VacationRequestViewModel>> GetRequestsAsync()
        {
            var listResult = await _xmpProxy.GetRequestsAsync(Filter);
            return listResult.Select(v => new VacationRequestViewModel(v));
        }
    }
}
