using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarkerDataCurrencyManager : IMarkerDataCurrencyService
    {
        private readonly RapidApiOptions _options;
        private readonly HttpClient _httpClient;

        public MarkerDataCurrencyManager(IOptions<RapidApiOptions> options, HttpClient httpClient)
        {
            _options = options.Value;
            _httpClient = httpClient;
        }

        public async Task<CurrencyApiResponse> GetCurrencyRate()
        {

            var baseUrl = _options.Services.Currency.BaseUrl;
            var endpoint = _options.Services.Currency.Endpoints.ExchangeRate;
            var client = _httpClient;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}{endpoint}?code=USD%2CEUR%2CGBP%2CCHF%2CSAR%2CAED%2CJPY%2CCNY%2CRUB%2CINR"),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.Currency.Host },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<CurrencyApiResponse>();
                return body;
                
            }
        }       
    }
}
