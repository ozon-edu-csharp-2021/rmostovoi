using MerchandiseService.Infrastructure.HttpFilters;
using MerchandiseService.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MerchandiseService.Infrastructure
{
    public static class InfrastructureAdding
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            return builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSwagger(false);
            });
        }

        public static IHostBuilder AddHttp(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => { options.Filters.Add<GlobalExceptionFilter>(); });
            });

            return builder;
        }
    }
}