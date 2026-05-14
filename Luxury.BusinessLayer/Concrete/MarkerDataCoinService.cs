using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarkerDataCoinService : IMarkerDataCoinService
    {
        private readonly IConfiguration _config;

        public MarkerDataCoinService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CryptoApiResponse> GetApiResponseAsync()
        {
            var baseUrl = _config["RapidApi:CoinBaseUrl"];
            var endpoint = _config["RapidApi:CoinEndpoint"];
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}{endpoint}?base_currency=TRY&page=1&page_size=10"),
                Headers =
                {
                    { "x-rapidapi-key", _config["RapidApi:CoinApiKey"] },
                    { "x-rapidapi-host", _config["RapidApi:CoinHost"] },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<CryptoApiResponse>();
                return body;
            }
            throw new NotImplementedException();

        }
    }
}
