using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Infrastructure.StartupFilters
{
    public class SwaggerStartupFilter : IStartupFilter
    {
        private const string SwaggerRelativeUrl = "/swagger/v1/swagger.json";

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(SwaggerRelativeUrl, "MerchandiseService v1"));
                next(app);
            };
        }
    }
}