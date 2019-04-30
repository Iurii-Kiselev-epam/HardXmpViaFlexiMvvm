using FlexiMvvm.ViewModels;
using System.Collections.Generic;
using System.Linq;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels.Profile
{
    public class RequestFilterViewModel : ViewModel
    {
        private RequestFilters _filter;

        public RequestFilterViewModel(RequestFilters filter)
        {
            Filter = filter;
        }

        public RequestFilters Filter
        {
            get => _filter;
            set => SetValue(ref _filter, value);
        }

        public string UiFilter
        {
            get => Filter.GetUiName();
        }

        public static IEnumerable<RequestFilterViewModel> GetAllFilters() =>
            RequestFiltersExtensions.GetAllRequests().Select(r => new RequestFilterViewModel(r));
    }
}
