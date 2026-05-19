using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class TopFiveDestinationsManager : ITopFiveDestinationsService
    {
        private readonly HttpClient _httpClient;
        private readonly RapidApiOptions _options;

        public TopFiveDestinationsManager(HttpClient httpClient, IOptions<RapidApiOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<TopFiveDestinationsResponse> GetApiResponseAsync()
        {
            var baseurl = _options.Services.TopFiveDestinations.BaseUrl;
            var endpoint = _options.Services.TopFiveDestinations.Endpoints.TopDestination;
            var client = _httpClient;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseurl}{endpoint}?languageCode=en-US&limit=5"),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.TopFiveDestinations.Host },
                },
            };
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadFromJsonAsync<TopFiveDestinationsResponse>();
            //    return body;
            //}
            return null;
        }
    }
}
