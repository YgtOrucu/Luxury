using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarkerDataWeatherManager : IMarkerDataWeatherService
    {
        private readonly RapidApiOptions _options;
        private readonly HttpClient _httpClient;

        public MarkerDataWeatherManager(IOptions<RapidApiOptions> options, HttpClient httpClient)
        {
            _options = options.Value;
            _httpClient = httpClient;
        }

        public async Task<WeatherApiResponse> GetWeatherData(string city, string lang)
        {
            var baseUrl = _options.Services.Weather.BaseUrl;
            var endpoint = _options.Services.Weather.Endpoints.City;
            var client = _httpClient;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}{endpoint}?city={city}&lang={lang}"),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.Weather.Host },
                },
            };

            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadFromJsonAsync<WeatherApiResponse>();
            //    return body;
            //    
            //}
            return null;
        }       
    }
}
