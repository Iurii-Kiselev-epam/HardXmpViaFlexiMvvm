using FlexiMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;

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
    }
}
