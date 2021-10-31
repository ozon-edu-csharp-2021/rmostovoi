using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        // ReSharper disable once UnusedParameter.Local
        public VersionMiddleware(RequestDelegate _)
        {
        }

        public Task InvokeAsync(HttpContext context)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            var version = assemblyName.Version?.ToString() ?? "unknown version";
            return context.Response.WriteAsJsonAsync(new
            {
                version,
                serviceName = assemblyName.Name
            });
        }
    }
}