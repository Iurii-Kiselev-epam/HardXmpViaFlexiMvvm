namespace VacationsTracker.Core.Infrastructure
{
    public class AppSettings : IAppSettings
    {
        public string VtsServiceUrl { get; } = @"https://vts-v2.azurewebsites.net/swagger/";
        public string VtsIdentityServiceUrl { get; } = @"https://vts-token-issuer-v2.azurewebsites.net/";
    }
}
