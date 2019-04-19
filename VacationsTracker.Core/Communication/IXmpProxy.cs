using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Communication
{
    public partial interface IXmpProxy : IDisposable
    {
        Task Authenticate(string login, string passw);
        Task<IEnumerable<VacationRequest>> GetRequestsAsync(RequestFilters filters = RequestFilters.All);
    }
}
