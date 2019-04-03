using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Infrastructure
{
    public interface IAppSettings
    {
        string VtsServiceUrl { get; }
        string VtsIdentityServiceUrl { get; }
    }
}
