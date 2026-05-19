namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class GetTheIdOfTheCityApiResponse
    {
        public Data[] data { get; set; }

    }

    public class Data
    { 
        public string id { get; set; }
    }
}
