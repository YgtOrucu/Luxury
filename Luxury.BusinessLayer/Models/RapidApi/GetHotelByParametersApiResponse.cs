namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class GetHotelByParametersApiResponse
    {
        public AllHotel[] data { get; set; }
    }

    public class AllHotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int propertyClass { get; set; }
        public int reviewCount { get; set; }
        public float reviewScore { get; set; }
        public string reviewScoreWord { get; set; }
        public string[] photoUrls { get; set; }
        public string wishlistName { get; set; }
        public string checkinDate { get; set; }
        public string checkoutDate { get; set; }
        public Pricebreakdown priceBreakdown { get; set; }
    }

    public class Pricebreakdown
    {
        public Grossprice grossPrice { get; set; }
    }

    public class Grossprice
    {
        public string amountRounded { get; set; }
    }

}