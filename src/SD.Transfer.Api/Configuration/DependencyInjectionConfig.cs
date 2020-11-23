using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Notifications;
using SD.Transfer.Business.Services;
using SD.Transfer.Data.Context;
using SD.Transfer.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SD.Transfer.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AccountDbContext>();

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();            

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<ILancamentoService, LancamentoService>();            

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();            

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}