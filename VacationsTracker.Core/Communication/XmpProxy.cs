using System;
using System.Net.Http;
using System.Threading.Tasks;
using VacationsTracker.Core.Infrastructure;

namespace VacationsTracker.Core.Communication
{
    public partial class XmpProxy
    {
        //private readonly ILogger _logger;
        private readonly IAppSettings _appSettings;

        public XmpProxy(
            IAppSettings appSettings
            //ILoggerFactory log
            )
            : this(httpClient: null) // Need to workaround
        {
            _appSettings = appSettings;
            BaseUrl = appSettings.VtsServiceUrl;
            _httpClient = new HttpClient(
                new HttpLoggingHandler(
                    new HttpClientHandler(),
                    //log,
                    MaskContent, 4096, RequestHeaderOptIn, ResponseHeaderOptIn));
            //_logger = log.GetLogger(nameof(XmpProxy));
        }

        public async Task Authenticate(string login, string passw)
        {
            //await _logger.Verbose(() => "Authenticating...");

            await _httpClient.Authenticate(login, passw, _appSettings.VtsIdentityServiceUrl);
            
            //await _logger.Verbose(() => "Authenticated");
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        private string MaskContent(string path, string content)
        {
            return content;
        }

        private bool RequestHeaderOptIn(string header)
        {
            return false;
        }

        private bool ResponseHeaderOptIn(string header)
        {
            return header == "Accept";
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
        }

        partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
        }
    }
}
