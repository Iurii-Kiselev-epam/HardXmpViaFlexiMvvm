namespace VacationsTracker.Core.Infrastructure
{
    public class AppSettings : IAppSettings
    {
        public string VtsServiceUrl { get; } = "http://localhost:5000";
        public string VtsIdentityServiceUrl { get; } = "http://localhost:5001";
    }
}
