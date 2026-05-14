using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarkerDataCoinService : IMarkerDataCoinService
    {
        private readonly RapidApiOptions _options;

        public MarkerDataCoinService(IOptions<RapidApiOptions> options)
        {
            _options = options.Value;
        }

        public async Task<CryptoApiResponse> GetApiResponseAsync()
        {
            var baseUrl = _options.Services.Crypto.BaseUrl;
            var endpoint = _options.Services.Crypto.Endpoints.MiniPrices;
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}{endpoint}?base_currency=TRY&page=1&page_size=10"),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.Crypto.Host },
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
