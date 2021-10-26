using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class ReadyMiddleware
    {
        // ReSharper disable once UnusedParameter.Local
        public ReadyMiddleware(RequestDelegate _)
        {
        }

        public Task InvokeAsync(HttpContext context)
        {
            return context.Response.WriteAsync("OK");
        }
    }
}