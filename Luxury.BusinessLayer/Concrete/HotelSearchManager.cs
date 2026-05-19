using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

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

            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadFromJsonAsync<GetHotelByParametersApiResponse>();
            //    if (body != null) return body;
            //    return null;
            //}

            var mockResponse = new GetHotelByParametersApiResponse
            {
                data = new AllHotel[]
        {
            new AllHotel
            {
                id = 26730,
                name = "Pullman Paris Tour Eiffel",
                propertyClass = 4,
                reviewCount = 5335,
                reviewScore = 8.2f,
                reviewScoreWord = "Çok İyi",
                wishlistName = "Paris",
                checkinDate = checkIn,
                checkoutDate = checkOut,
                photoUrls = new string[] { "https://cf.bstatic.com/xdata/images/hotel/max430/748428807.jpg?k=bfa9eb8c33e4d8dc014668e2e453606283adb89fcc23a5eff59d8bbe56a43d54&o=" },
                priceBreakdown = new Pricebreakdown
                {
                    grossPrice = new Grossprice
                    {
                        amountRounded = "TL 100.063"
                    }
                }
            }
        }
            };
            return mockResponse;
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
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadFromJsonAsync<GetTheIdOfTheCityApiResponse>();
            //    var id = body.data.FirstOrDefault().id;
            //    if (id != null) return id;
            //    return null;
            //}
            return "eyJjaXR5X25hbWUiOiJQYXJpcyIsImNvdW50cnkiOiJGcmFuY2UiLCJkZXN0X2lkIjoiLTE0NTY5MjgiLCJkZXN0X3R5cGUiOiJjaXR5In0=";
        }
    }
}
