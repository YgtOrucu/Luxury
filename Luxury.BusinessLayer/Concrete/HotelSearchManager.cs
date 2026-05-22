using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class HotelSearchManager : IHotelSearchService
    {
        private readonly HttpClient _httpClient;
        private readonly RapidApiOptions _options;

        public HotelSearchManager(HttpClient httpClient, IOptions<RapidApiOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<GetHotelByParametersApiResponse> GetHotelByParameters(string id, string checkIn, string checkOut, int adults,
     string children, int rooms, string units, string currencyCode, string Language, string temperature)
        {
            var baseurl = _options.Services.GetHotelByParameters.BaseUrl;
            var endpoint = _options.Services.GetHotelByParameters.Endpoints.GetAllHotelByParameters;
            var client = _httpClient;

            var urlBuilder = $"{baseurl}{endpoint}?locationId={id}&checkinDate={checkIn}&checkoutDate={checkOut}&rooms={rooms}&adults={adults}";

            if (!string.IsNullOrWhiteSpace(children) && children.Trim() != "0")
            {
                urlBuilder += $"&children={children.Trim()}";
            }

            urlBuilder += $"&units={units}&temperature={temperature}&languageCode={Language}&currencyCode={currencyCode}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(urlBuilder),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.GetHotelByParameters.Host },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<GetHotelByParametersApiResponse>();
                if (body != null) return body;
                return null;
            }
        }


        public async Task<string> GetIdByCityNameAsync(string cityname)
        {
            var baseurl = _options.Services.GetIdByCityName.BaseUrl;
            var endpoint = _options.Services.GetIdByCityName.Endpoints.GetDestination;
            var client = _httpClient;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseurl}{endpoint}?query={cityname}"),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.GetIdByCityName.Host },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<GetTheIdOfTheCityApiResponse>();
                var id = body.data.FirstOrDefault().id;
                if (id != null) return id;
                return null;
            }
        }

        public async Task<GetHotelDetailByIdApiResponse> GetHotelDetailsById(int hotelId, string checkInDate, string checkOutDate, int rooms, 
            int adults, string units, string currencyCode, string language, string children)
        {
            var baseurl = _options.Services.GetHotelDetailsById.BaseUrl;
            var endpoint = _options.Services.GetHotelDetailsById.Endpoints.GetHotelDetailById;
            var client = _httpClient;

            var urlBuilder = $"{baseurl}{endpoint}?hotelId={hotelId}&checkinDate={checkInDate}&checkoutDate={checkOutDate}&rooms={rooms}&adults={adults}";

            if (!string.IsNullOrWhiteSpace(children) && children.Trim() != "0")
            {
                urlBuilder += $"&children={children.Trim()}";
            }

            urlBuilder += $"&units={units}&languageCode={language}&currencyCode={currencyCode}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(urlBuilder),
                Headers =
                {
                    { "x-rapidapi-key", _options.ApiKey },
                    { "x-rapidapi-host", _options.Services.GetHotelDetailsById.Host },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var body = await response.Content.ReadFromJsonAsync<GetHotelDetailByIdApiResponse>(options);
                if (body != null) return body;
                return null;
            }
        }
    }
}
