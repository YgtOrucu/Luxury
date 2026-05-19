using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Luxury.BusinessLayer.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IMarketDataService, MarketDataManager>();
            services.AddScoped<IMarkerDataCurrencyService, MarkerDataCurrencyManager>();
            services.AddScoped<IMarkerDataCoinService, MarkerDataCoinManager>();
            services.AddScoped<IMarkerDataFuelService, MarkerDataFuelManager>();
            services.AddScoped<IMarkerDataWeatherService, MarkerDataWeatherManager>();
            services.AddScoped<ITopFiveDestinationsService, TopFiveDestinationsManager>();
            services.AddScoped<IHotelSearchService,HotelSearchManager>();

            return services;
        }
    }
}