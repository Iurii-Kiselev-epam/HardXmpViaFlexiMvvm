﻿using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
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
    public class MainListViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;
        private bool _progressVisible;
        private RequestFilters _filter;

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
            set
            {
                SetValue(ref _progressVisible, value);
                RaisePropertyChanged(nameof(IsUIVisible));
            }
        }

        public bool IsUIVisible
        {
            get => !_progressVisible;
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
            get
            {
                switch(Filter)
                {
                    case RequestFilters.All:
                        return Strings.All_Requests;
                    case RequestFilters.Open:
                        return Strings.Open_Requests;
                    case RequestFilters.Closed:
                    default:
                        return Strings.Closed_Requests;
                }
            }
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

        private void OpenVacationDetails(VacationRequestViewModel itemViewModel)
        {
            // TODO: navigate to details
            //_navigationService.NavigateToEventDetails(this, new EventDetailsParameters { EventId = itemViewModel.Id });
        }

        public ICommand NewRequestCommand => CommandProvider.GetForAsync(OnNewRequest);

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
