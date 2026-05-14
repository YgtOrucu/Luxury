using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarkerDataFuelService : IMarkerDataFuelService
    {
        private readonly RapidApiOptions _options;

        public MarkerDataFuelService(IOptions<RapidApiOptions> options)
        {
            _options = options.Value;
        }

        public async Task<FuelApiResponse> GetFuelPrices()
        {
            var baseurl = _options.Services.Fuel.BaseUrl;
            var endpoint = _options.Services.Fuel.Endpoints.EuropaCountry;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseurl}{endpoint}"),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.Fuel.Host },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<FuelApiResponse>();
                return body;
            }
        }
    }
}
