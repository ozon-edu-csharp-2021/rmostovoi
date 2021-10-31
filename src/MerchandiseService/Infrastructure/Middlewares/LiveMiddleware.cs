using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class LiveMiddleware
    {
        // ReSharper disable once UnusedParameter.Local
        public LiveMiddleware(RequestDelegate _)
        {
        }

        public Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            return context.Response.WriteAsync("OK");
        }
    }
}