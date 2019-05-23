using FlexiMvvm.ViewModels;
using System.Collections.Generic;
using System.Linq;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels.Profile
{
    public class RequestFilterViewModel : ViewModel
    {
        private RequestFilters _filter;
        private bool _isSelected;

        public RequestFilterViewModel(RequestFilters filter, bool isSelected)
        {
            Filter = filter;
            _isSelected = isSelected;
        }

        public RequestFilters Filter
        {
            get => _filter;
            set => SetValue(ref _filter, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetValue(ref _isSelected, value);
        }

        public string UiFilter
        {
            get => Filter.GetUiNameShortcut();
        }

        public static IEnumerable<RequestFilterViewModel> GetAllFilters(RequestFilters selectedFilter) =>
            RequestFiltersExtensions.GetAllRequests().Select(r => new RequestFilterViewModel(r, r == selectedFilter));
    }
}
