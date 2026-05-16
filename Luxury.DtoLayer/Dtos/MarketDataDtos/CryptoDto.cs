namespace Luxury.DtoLayer.Dtos.MarketDataDtos
{
    public class CryptoDto
    {
        public string symbol { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public string image { get; set; }

        public decimal change_24h_percent { get; set; }
    }
}
