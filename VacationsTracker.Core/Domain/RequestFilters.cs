using VacationsTracker.Core.Resources;

namespace VacationsTracker.Core.Domain
{
    public enum RequestFilters
    {
        All = 0,
        Open,
        Closed
    }

    public static class RequestFiltersExtensions
    {
        public static string GetUiName(this RequestFilters filters)
        {
            switch (filters)
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
