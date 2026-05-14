using Luxury.BusinessLayer.Abstract;
using Luxury.BusinessLayer.Models.RapidApi.Luxury.BusinessLayer.Models.RapidApi;
using Luxury.DtoLayer.Dtos.MarketDataDtos;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Net.Http.Json;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarketDataService : IMarketDataService
    {
        private readonly IConfiguration _config;
        private readonly IMarkerDataCurrencyService _currencyService;
        private readonly IMarkerDataCoinService _coinService;

        public MarketDataService(
            IConfiguration config,
            IMarkerDataCurrencyService currencyService,
            IMarkerDataCoinService coinService)
        {
            _config = config;
            _currencyService = currencyService;
            _coinService = coinService;
        }

        public async Task<MarketDataDto> GetMarkerDataAsync()
        {
            /*CURRENCY API RAPIDAPI*/
            //var currencyresponse = await _currencyService.GetCurrencyRate();
            //var currency = currencyresponse.data.Select(x=> new CurrencyDto
            //{
            //   Name = x.code,
            //   ShortName = x.ShortName,
            //   Price = x.buying,
            //   ChangeRate = x.changeRate

            //}).ToList();
            /*CURRENCY API RAPIDAPI*/

            /*WEATHER API RAPIDAPI*/
            //var cities = new[] { "Istanbul", "Ankara", "Izmir", "Antalya"};
            //var weatherList = new List<WeatherDto>();
            //foreach (var city in cities)
            //{
            //    var weatherresponse = await GetWeatherDataAsync(city, "TR");
            //
            //    weatherList.Add(new WeatherDto
            //    {
            //        City = weatherresponse.name,
            //        Temp = (int)Math.Round((weatherresponse.main.temp - 32) * 5 / 9),
            //        Visibility = weatherresponse.visibility / 1000,
            //        Humidity = weatherresponse.main.humidity,
            //        Wind = (int)weatherresponse.wind.speed,
            //        Icon = weatherresponse.weather[0].main,
            //        WeatherIcon = weatherresponse.weather[0].main switch
            //        {
            //            "Clear" => "☀️",
            //            "Clouds" => "☁️",
            //            "Rain" => "🌧️",
            //            "Drizzle" => "🌦️",
            //            "Thunderstorm" => "⛈️",
            //            "Snow" => "❄️",
            //            "Mist" or "Fog" or "Haze" => "🌫️",
            //            _ => "🌍"
            //        }
            //    });
            //}
            /*WEATHER API RAPIDAPI*/



            /*COİN API RAPIDAPI*/
            //var coinResponse = await _coinService.GetApiResponseAsync();

            //var coins = coinResponse.results.Take(10).Select(c => new CryptoDto
            //{
            //    Name = c.name,
            //    Symbol = c.symbol,
            //    Price = c.price,
            //    Change = c.change_24h_percent,
            //    Image = c.image
            //}).ToList();
            /*COİN API RAPIDAPI*/




            return new MarketDataDto
            {
                //Currency = currency,
                //Weather = weatherList,
                //Coins = coins
            };
        }

        private async Task<WeatherApiResponse> GetWeatherDataAsync(string city, string lang)
        {
            var baseUrl = _config["RapidApi:WeatherBaseUrl"];
            var endpoint = _config["RapidApi:WeatherEndpoint"];
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}{endpoint}?city={city}&lang={lang}"),
                Headers =
                {
                    { "x-rapidapi-key", _config["RapidApi:WeatherApiKey"] },
                    { "x-rapidapi-host", _config["RapidApi:WeatherHost"] },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<WeatherApiResponse>();
                return body;
            }
            throw new NotImplementedException();
        }
    }
}