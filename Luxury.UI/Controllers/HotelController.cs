using Humanizer;
using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Luxury.UI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HotelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            ViewBag.Adults = TempData["Adults"];
            ViewBag.Rooms = TempData["Rooms"];
            ViewBag.Children = TempData["Children"];

            List<ResultHotelDto> hotels = new List<ResultHotelDto>();

            if (TempData["AllHotels"] != null)
            {
                var jsonString = TempData["AllHotels"].ToString();
                hotels = JsonSerializer.Deserialize<List<ResultHotelDto>>(jsonString);
                return View(hotels);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(HotelSearchFormDto dto)
        {
            var agesList = Enumerable.Repeat(dto.DefaultAge, dto.Children);
            string childrenParam = string.Join(",", agesList);


            var client = _httpClientFactory.CreateClient("LuxuryApi");
            var responsebodyforgetcityname = await client.GetAsync($"HotelSearch/GetIdByCityName?cityname={dto.City}");

            if (responsebodyforgetcityname.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var error = await responsebodyforgetcityname.Content.ReadAsStringAsync();
                return View(error);
            }

            if (responsebodyforgetcityname.IsSuccessStatusCode)
            {
                var targetCityId = await responsebodyforgetcityname.Content.ReadAsStringAsync();

                var queryParams = new List<string>
                {
                    $"id={Uri.EscapeDataString(targetCityId)}",
                    $"CheckIn={dto.CheckIn}",
                    $"CheckOut={dto.CheckOut}",
                    $"Adults={dto.Adults}",
                    $"Rooms={dto.Rooms}",
                    $"Units={dto.Units}",
                    $"CurrencyCode={dto.CurrencyCode}",
                    $"Language={dto.Language}",
                    $"Temperature={dto.Temperature}"
                };

                if (!string.IsNullOrWhiteSpace(childrenParam))
                {
                    queryParams.Add($"Children={childrenParam.Trim()}");
                }

                var requestUrl = $"HotelSearch/GetHotelByParametres?{string.Join("&", queryParams)}";

                var responseGetSearchHotel = await client.GetAsync(requestUrl);

                if (responseGetSearchHotel.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var error = await responseGetSearchHotel.Content.ReadAsStringAsync();
                    return View(error);
                }

                if (responseGetSearchHotel.IsSuccessStatusCode)
                {
                    var values = new List<ResultHotelDto>();

                    if (responseGetSearchHotel.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        values = await responseGetSearchHotel.Content.ReadFromJsonAsync<List<ResultHotelDto>>() ?? new List<ResultHotelDto>();
                    }

                    TempData["AllHotels"] = JsonSerializer.Serialize(values);
                    TempData["Adults"] = dto.Adults;
                    TempData["Rooms"] = dto.Rooms;
                    TempData["Children"] = dto.Children;

                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string checkInDate, string checkOutDate, int rooms, 
            int adults, int children, string units, string currencyCode, string language)
        {
            int DefaultAge = 1;
            var agesList = Enumerable.Repeat(DefaultAge, children);
            string childrenParam = string.Join(",", agesList);

            var queryParams = new List<string>
                {
                    $"hotelId={id}",
                    $"checkInDate={checkInDate}",
                    $"checkOutDate={checkOutDate}",
                    $"rooms={rooms}",
                    $"adults={adults}",
                    $"units={units}",
                    $"currencyCode={currencyCode}",
                    $"language={language}"
                };

            if (!string.IsNullOrWhiteSpace(childrenParam))
            {
                queryParams.Add($"children={childrenParam.Trim()}");
            }

            var requestUrl = $"HotelSearch/GetHotelDetailById?{string.Join("&", queryParams)}";

            var client = _httpClientFactory.CreateClient("LuxuryApi");
            var responseGetHotelDetails = await client.GetAsync(requestUrl);


            if (responseGetHotelDetails.IsSuccessStatusCode)
            {
                var values = new HotelDetailDto();

                if (responseGetHotelDetails.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    values = await responseGetHotelDetails.Content.ReadFromJsonAsync<HotelDetailDto>() ?? new HotelDetailDto();
                }
                return View(values);
            }
            var x = responseGetHotelDetails.Content.ReadAsStringAsync();
            return View();
        }
    }
}
