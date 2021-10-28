using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Interceptors
{
    public class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            TryLogRequest(request);
            var response = await base.UnaryServerHandler(request, context, continuation);
            TryLogResponse(response);
            return response;
        }

        private void TryLogRequest<T>(T request)
        {
            try
            {
                var json = request?.ToString();
                _logger.LogInformation("Grpc Request: {Request}", json);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Couldn't log GRPC request");
            }
        }

        private void TryLogResponse<T>(T response)
        {
            try
            {
                var json = response?.ToString();
                _logger.LogInformation("Grpc Response: {Response}", json);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Couldn't log GRPC response");
            }
        }

        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncServerStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            _logger.LogInformation("Streaming has been called");
            return base.AsyncServerStreamingCall(request, context, continuation);
        }
    }
}