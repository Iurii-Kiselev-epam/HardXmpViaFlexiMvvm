using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string GetUiNameShortcut(this RequestFilters filters)
        {
            switch (filters)
            {
                case RequestFilters.All:
                    return Strings.All_Requests_Shortcut;
                case RequestFilters.Open:
                    return Strings.Open_Requests_Shortcut;
                case RequestFilters.Closed:
                default:
                    return Strings.Closed_Requests_Shortcut;
            }
        }

        public static IEnumerable<RequestFilters> GetAllRequests()
        {
            foreach (var rqst in Enum.GetValues(typeof(RequestFilters)))
            {
                yield return (RequestFilters)rqst;
            }
        }

        public static IEnumerable<string> GetAllUiRequests() =>
            GetAllRequests().Select(r => r.GetUiName());
    }
}
