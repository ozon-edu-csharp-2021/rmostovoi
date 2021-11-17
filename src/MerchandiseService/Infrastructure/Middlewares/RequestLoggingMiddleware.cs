using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await TryLogRequest(context.Request);
            await _next(context);
        }

        private async Task TryLogRequest(HttpRequest request)
        {
            var isLogged = false;
            try
            {
                if (request.Path.StartsWithSegments("/swagger")) return;
                if (request.ContentType == "application/grpc") return;

                LogRequestInfo(request);
                LogRequestHeaders(request);
                var text = await ReadRequestBodyAsText(request);
                if (text is not null)
                {
                    isLogged = true;
                    _logger.LogInformation("[Request Body]: {RequestBody}", text);
                }
                else
                {
                    _logger.LogInformation("Request is empty");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Couldn't log request");
            }
            finally
            {
                if (isLogged) request.Body.Seek(0, SeekOrigin.Begin);
            }
        }

        private void LogRequestInfo(HttpRequest request)
        {
            _logger.LogInformation("[Request Info] " +
                                   "Schema: {Schema}" +
                                   "Host: {Host} " +
                                   "Path: {Path} " +
                                   "QueryString: {QueryString} ",
                request.Scheme,
                request.Host,
                request.Path,
                request.QueryString
            );
        }

        private void LogRequestHeaders(HttpRequest request)
        {
            _logger.LogInformation("[Request Headers]: {@Headers}", request.Headers);
        }

        private static async Task<string?> ReadRequestBodyAsText(HttpRequest request)
        {
            if (request.ContentLength is null or 0) return null;

            request.EnableBuffering();
            byte[] buffer = new byte[request.ContentLength.GetValueOrDefault()];
            await request.Body.ReadAsync(buffer);
            var text = Encoding.UTF8.GetString(buffer);
            return text;
        }
    }
}