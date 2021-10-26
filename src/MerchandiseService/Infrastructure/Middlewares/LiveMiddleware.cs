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
            return context.Response.WriteAsync("OK");
        }
    }
}