using System;
using System.IO;
using System.Reflection;
using MerchandiseService.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MerchandiseService.Infrastructure
{
    public static class SwaggerAdding
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, bool includeXmlComments)
        {
            services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MerchandiseService", Version = "v1" });
                c.CustomSchemaIds(it => it.FullName);
                if (includeXmlComments)
                {
                    //requires GenerateDocumentationFile property set to true in .csproj
                    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                    if (!File.Exists(xmlPath))
                        throw new FileNotFoundException("Project's xml file not found. " +
                                                        "Set property GenerateDocumentationFile to true in .csproj");

                    c.IncludeXmlComments(xmlPath);
                }
            });
            return services;
        }
    }
}