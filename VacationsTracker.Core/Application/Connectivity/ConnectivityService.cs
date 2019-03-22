using VacationsTracker.Core.Infrastructure.Connectivity;
using Xamarin.Essentials;

namespace VacationsTracker.Core.Application.Connectivity
{
    public class ConnectivityService : IConnectivityService
    {
        private readonly IConnectivity _connectivity;

        public ConnectivityService(IConnectivity connectivity)
        {
            _connectivity = connectivity;
        }

        public bool IsConnected => _connectivity.NetworkAccess != NetworkAccess.None;
    }
}
