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
            //HttpResponseMessage response = null;
            //Exception exCaught = null;

            try
            {
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false); //(response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                //exCaught = ex;
                throw;
            }
            //finally
            //{
            //    var isFull = exCaught != null && AppSettings.Current.LogLevel >= TraceLevel.Error ||
            //        response == null ||
            //        !response.IsSuccessStatusCode ||
            //        AppSettings.Current.LogLevel == TraceLevel.Verbose;

            //    if (isFull || AppSettings.Current.LogLevel >= TraceLevel.Info)
            //    {
            //        await DoLog(request, response, isFull).ConfigureAwait(false);
            //    }
            //}
        }

        //private async Task DoLog(HttpRequestMessage req, HttpResponseMessage resp, bool isFull)
        //{
        //    var req0 = req != null ? $"{req.Method} {req.RequestUri.PathAndQuery}" : "NULL";
        //    var resp0 = resp != null ? $"{(int)resp.StatusCode} {resp?.Content?.Headers?.ContentType?.MediaType}" : "NULL";
        //    var prefix = $"{req0} >>> {resp0}";

        //    if (!isFull)
        //    {
        //        await _logger.Info(() => prefix).ConfigureAwait(false);
        //        return;
        //    }

        //    // ...Otherwise, need more details

        //    var reqContent = await GetContent(req?.RequestUri.PathAndQuery, req?.Content);
        //    var respContent = await GetContent(req?.RequestUri.PathAndQuery, resp?.Content);

        //    // ...Including headers

        //    var reqHeaders = _requestHeaderOptIn != null && req != null ? req.Headers.Where(h => _requestHeaderOptIn(h.Key)) : null;
        //    var respHeaders = _responseHeaderOptIn != null && resp != null ? resp.Headers.Where(h => _responseHeaderOptIn(h.Key)).ToList() : null;
        //    if (_responseHeaderOptIn != null && resp != null)
        //    {
        //        respHeaders?.AddRange(resp.Content.Headers.Where(h => _responseHeaderOptIn(h.Key)));
        //    }

        //    // Build full log


        //    var reqHeadersContent = reqHeaders != null ? HeadersToString(reqHeaders.ToArray()) : null;
        //    if (reqHeadersContent != null)
        //    {
        //        reqContent = reqContent + Environment.NewLine + reqHeadersContent;
        //    }
        //    var respHeadersContent = respHeaders != null ? HeadersToString(respHeaders.ToArray()) : null;
        //    if (respHeadersContent != null)
        //    {
        //        respContent = respContent + Environment.NewLine + respHeadersContent;
        //    }

        //    var result = string.Join(Environment.NewLine, new[]
        //    {
        //        prefix,
        //        reqContent ?? "No Request content",
        //        respContent ?? "No Response content"
        //    });

        //    await _logger.Verbose(() => result).ConfigureAwait(false);
        //}

        //private async Task<string> GetContent(string path, HttpContent content)
        //{
        //    if (content == null) return null;

        //    var str = await content.ReadAsStringAsync();
        //    if (string.IsNullOrEmpty(str)) return null;

        //    if (_truncCount > 0 && str.Length > _truncCount)
        //    {
        //        str = str.Substring(0, _truncCount);
        //    }

        //    if (_requestMasker != null && path != null)
        //    {
        //        str = _requestMasker(path, str);
        //    }

        //    return str;
        //}

        //private string HeadersToString(KeyValuePair<string, IEnumerable<string>>[] headers)
        //{
        //    if (headers == null || headers.Length == 0) return null;
        //    return string.Join(Environment.NewLine, headers.Select(h => $"* {h.Key} = {string.Join(";", h.Value)}"));
        //}
    }
}
