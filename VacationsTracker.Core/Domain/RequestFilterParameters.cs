using FlexiMvvm.ViewModels;

namespace VacationsTracker.Core.Domain
{
    public class RequestFilterParameters : Parameters
    {
        public RequestFilters Filter
        {
            get => Bundle.GetEnum<RequestFilters>();
            set => Bundle.SetEnum(value);
        }
    }
}
