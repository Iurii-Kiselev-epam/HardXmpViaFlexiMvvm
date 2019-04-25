using FlexiMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.Core.Presentation.ViewModels.Profile
{
    public class ProfileViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private RequestFilters _filter;

        public ProfileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
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
                switch (Filter)
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

    }
}
