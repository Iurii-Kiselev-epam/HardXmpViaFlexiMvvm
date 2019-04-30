using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using System;
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
            Filters = new ObservableCollection<RequestFilterViewModel>();
        }

        public ObservableCollection<RequestFilterViewModel> Filters
        {
            get;
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

        public Command<RequestFilterViewModel> OpenFilterCommand =>
            CommandProvider.Get<RequestFilterViewModel>(OpenFilter);


        public override void Initialize()
        {
            base.Initialize();

            Filters.Clear();
            Filters.AddRange(RequestFilterViewModel.GetAllFilters());
        }

        private void OpenFilter(RequestFilterViewModel itemViewModel)
        {
            // TODO: navigate to profile
            //_navigationService.NavigateToEventDetails(this, new EventDetailsParameters { EventId = itemViewModel.Id });
        }

    }
}
