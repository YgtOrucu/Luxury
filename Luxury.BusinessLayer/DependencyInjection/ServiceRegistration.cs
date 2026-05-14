using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Luxury.BusinessLayer.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IMarketDataService, MarketDataService>();
            services.AddScoped<IMarkerDataCurrencyService, MarkerDataCurrencyService>();
            services.AddScoped<IMarkerDataCoinService, MarkerDataCoinService>();
            services.AddScoped<IMarkerDataFuelService, MarkerDataFuelService>();

            return services;
        }
    }
}