namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class TopFiveDestinationsResponse
    {
        public Destination[] destinations { get; set; }
        public City[] cities { get; set; }
    }

    public class Destination
    {
        public string name { get; set; }
        public string imageUrl { get; set; }
        public float averagePrice { get; set; }
        public int hotelCount { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string imageUrl { get; set; }
        public float averagePrice { get; set; }
        public int hotelCount { get; set; }
    }
}

