using MerchandiseService.Application;
using MerchandiseService.Application.Repositories;
using MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using MerchandiseService.Domain.AggregationModels.MerchInquiryAggregate;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using MerchandiseService.GrpcServices;
using MerchandiseService.Services;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IModelsMapperService, ModelsMapperService>();
            services.AddSingleton<IClock, Clock>();
            services.AddScoped<IMerchService, MerchService>();
            services.AddScoped<IMerchItemRepository, MerchItemRepositoryPg>();
            services.AddScoped<IIssuedMerchRepository, IssuedMerchRepositoryPg>();
            services.AddScoped<IMerchInquiryRepository, MerchInquiryRepositoryPg>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchApiGrpcService>();
                endpoints.MapControllers();
            });
        }
    }
}