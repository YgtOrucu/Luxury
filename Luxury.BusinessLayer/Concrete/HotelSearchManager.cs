using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.BusinessLayer.Settings;
using Luxury.DtoLayer.Dtos.HotelSearchDtos;
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


            //var mockResponse = new GetHotelByParametersApiResponse
            //{
            //    data = new AllHotel[]
            //    {
            //        new AllHotel
            //        {
            //            id = 9225954,
            //            name = "Hilton Garden Inn Paris La Villette",
            //            propertyClass = 4,
            //            reviewCount = 826,
            //            reviewScore = 8.5f,
            //            reviewScoreWord = "Çok İyi",
            //            wishlistName = "Paris",
            //            checkinDate = checkIn,
            //            checkoutDate = checkOut,
            //            photoUrls = new string[] { "https://cf.bstatic.com/xdata/images/hotel/max430/753532290.jpg?k=5df1045ce999e9bfd89e9406a7879f8ac37e409458c8fe893ec34e423af862fc&o=" },
            //            priceBreakdown = new Pricebreakdown
            //            {
            //                grossPrice = new Grossprice
            //                {
            //                    amountRounded = "TL 116.359"
            //                }
            //            }
            //        },
            //         new AllHotel
            //        {
            //            id = 57218,
            //            name = "Novotel Paris 14 Porte d'Orléans",
            //            propertyClass = 4,
            //            reviewCount = 3834,
            //            reviewScore = 8.2f,
            //            reviewScoreWord = "Çok İyi",
            //            wishlistName = "Paris",
            //            checkinDate = checkIn,
            //            checkoutDate = checkOut,
            //            photoUrls = new string[] { "https://cf.bstatic.com/xdata/images/hotel/max430/870663839.jpg?k=ace534c7f65820df0d4008582a2ef9531cdcd1918776fc828e8e3d64218db0f7&o=" },
            //            priceBreakdown = new Pricebreakdown
            //            {
            //                grossPrice = new Grossprice
            //                {
            //                    amountRounded = "TL 112.958"
            //                }
            //            }
            //        },
            //    }
            //};
            //return mockResponse;
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
