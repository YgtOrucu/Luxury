namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class CryptoApiResponse
    {
        public int page { get; set; }
        public int page_size { get; set; }
        public string base_currency { get; set; }
        public List<CryptoResult> results { get; set; } = [];
    }

    public class CryptoResult
    {
        public int rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string id { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public decimal market_cap { get; set; }
        public decimal change_24h_percent { get; set; }
    }
}

