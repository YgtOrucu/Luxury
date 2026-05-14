using Luxury.BusinessLayer.Models.RapidApi;

namespace Luxury.BusinessLayer.Abstract
{
    public interface IMarkerDataWeatherService
    {
        Task<WeatherApiResponse> GetWeatherData(string city, string lang);
    }
}
