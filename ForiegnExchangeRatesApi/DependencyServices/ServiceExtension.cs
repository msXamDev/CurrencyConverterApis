using ForiegnExchangeRatesApi.Services.GetExchangeRate;

namespace ForiegnExchangeRatesApi.DependencyServices
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(
               this IServiceCollection services)
        {
            services.AddTransient<IGetExchangeRateManager, GetExchangeRateManager>();
            return services;
        }
    }
}
