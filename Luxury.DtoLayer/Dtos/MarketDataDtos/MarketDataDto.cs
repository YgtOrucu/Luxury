namespace Luxury.DtoLayer.Dtos.MarketDataDtos
{
    public class MarketDataDto
    {
        public List<CurrencyDto> Currency { get; set; }
        public List<WeatherDto> Weather { get; set; }
        public List<CryptoDto> Coins { get; set; }
        public FuelDto Fuel { get; set; }
    }
}
