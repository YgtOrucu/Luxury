namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class CurrencyApiResponse
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public string code { get; set; }
        public string ShortName { get; set; }
        public float buying { get; set; }
        public float changeRate { get; set; }
    }


}

