using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarkerDataCurrencyService : IMarkerDataCurrencyService
    {
        private readonly IConfiguration _config;

        public MarkerDataCurrencyService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CurrencyApiResponse> GetCurrencyRate()
        {

            var baseUrl = _config["RapidApi:CurrencyBaseUrl"];
            var endpoint = _config["RapidApi:CurrencyEndpoint"];
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}{endpoint}?code=USD%2CEUR%2CGBP%2CCHF%2CSAR%2CAED%2CJPY%2CCNY%2CRUB%2CINR"),
                Headers =
                {
                    { "x-rapidapi-key", _config["RapidApi:CurrencyApiKey"] },
                    { "x-rapidapi-host", _config["RapidApi:CurrencyHost"] },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<CurrencyApiResponse>();
                return body;
                
            }
            throw new NotImplementedException();
        }       
    }
}
