using AutoMapper;
using Luxury.BusinessLayer.Abstract;
using Luxury.DtoLayer.Dtos.MarketDataDtos;

namespace Luxury.BusinessLayer.Concrete
{
    public class MarketDataService : IMarketDataService
    {
        private readonly IMarkerDataCurrencyService _currencyService;
        private readonly IMarkerDataCoinService _coinService;
        private readonly IMarkerDataFuelService _fuelService;
        private readonly IMarkerDataWeatherService _weatherService;
        private readonly IMapper _mapper;
        public MarketDataService(
            IMarkerDataCurrencyService currencyService,
            IMarkerDataCoinService coinService,
            IMarkerDataFuelService fuelService,
            IMarkerDataWeatherService weatherService,  
            IMapper mapper)
        {
            _currencyService = currencyService;
            _coinService = coinService;
            _fuelService = fuelService;
            _weatherService = weatherService; 
            _mapper = mapper;
        }

        public async Task<MarketDataDto> GetMarkerDataAsync()
        {
            /*CURRENCY API RAPIDAPI*/
            var currencyresponse = await _currencyService.GetCurrencyRate();
            var currency = currencyresponse != null ? _mapper.Map<List<CurrencyDto>>(currencyresponse.data) : null;
            /*CURRENCY API RAPIDAPI*/

            /*----------------------------------------*/

            /*WEATHER API RAPIDAPI*/
            var cities = new[] { "Istanbul", "Ankara", "Izmir", "Antalya" };
            var weatherList = new List<WeatherDto>();
            foreach (var city in cities)
            {
                var weatherresponse = await _weatherService.GetWeatherData(city, "TR");
                if (weatherresponse == null) continue;
                weatherList.Add(_mapper.Map<WeatherDto>(weatherresponse));
            }
            /*WEATHER API RAPIDAPI*/

            /*----------------------------------------*/

            /*COİN API RAPIDAPI*/
            var coinResponse = await _coinService.GetApiResponseAsync();
            var coins = coinResponse != null ? _mapper.Map<List<CryptoDto>>(coinResponse.results.Take(10)) : null;
            /*COİN API RAPIDAPI*/

            /*----------------------------------------*/

            /*Fuel API RAPIDAPI*/
            var fuelresponse = await _fuelService.GetFuelPrices();
            var fuel = fuelresponse != null ? _mapper.Map<FuelDto>(fuelresponse.result.Where(x => x.country == "Turkey")) : null;
            /*Fuel API RAPIDAPI*/

            /*----------------------------------------*/

            return new MarketDataDto
            {
                Currency = currency,
                Weather = weatherList,
                Coins = coins,
                Fuel = fuel,
            };
        }
    }
}