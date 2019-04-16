using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class MainListViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;
        private bool _progressVisible;

        public MainListViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _xmpProxy = xmpProxy ?? throw new ArgumentNullException(nameof(xmpProxy));

            ProgressVisible = true;
            VacationRequests = new ObservableCollection<VacationRequestViewModel>();
        }

        public bool ProgressVisible
        {
            get => _progressVisible;
            set => SetValue(ref _progressVisible, value);
        }

        public ObservableCollection<VacationRequestViewModel> VacationRequests
        {
            get;
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            try
            {
                var listResult = await _xmpProxy.VtsVacationGetListAsync();
                var vacations = listResult.Result.Select(v => new VacationRequestViewModel(v)).ToList();

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

        private void OpenVacationDetails(VacationRequestViewModel itemViewModel)
        {
            // TODO: navigate to details
            //_navigationService.NavigateToEventDetails(this, new EventDetailsParameters { EventId = itemViewModel.Id });
        }
    }
}
