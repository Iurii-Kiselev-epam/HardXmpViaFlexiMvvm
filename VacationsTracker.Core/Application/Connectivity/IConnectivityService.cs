using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Application.Connectivity
{
    public interface IConnectivityService
    {
        bool IsConnected { get; }
    }
}
