using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VacationsTracker.Core.Communication
{
    public class HttpLoggingHandler : DelegatingHandler
    {
        //private readonly ILogger _logger;
        private readonly Func<string, string, string> _requestMasker;
        private readonly Func<string, bool> _requestHeaderOptIn;
        private readonly Func<string, bool> _responseHeaderOptIn;
        private readonly int _truncCount;

        public HttpLoggingHandler(
            HttpMessageHandler innerHandler,
            //ILoggerFactory log,
            Func<string, string, string> requestMasker = null,
            int? truncCount = null,
            Func<string, bool> requestHeaderOptIn = null,
            Func<string, bool> responseHeaderOptIn = null)
            : base(innerHandler)
        {
            //_logger = log.GetLogger(nameof(HttpClient));
            _requestMasker = requestMasker;
            _truncCount = truncCount ?? 0;
            _requestHeaderOptIn = requestHeaderOptIn;
            _responseHeaderOptIn = responseHeaderOptIn;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // TODO: log exception...
                // ui message?
                throw;
            }
        }
    }
}
