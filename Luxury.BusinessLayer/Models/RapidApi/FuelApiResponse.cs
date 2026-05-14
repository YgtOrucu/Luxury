namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class FuelApiResponse
    {
        public Result[] result { get; set; }
    } 

    public class Result
    {
        public string lpg { get; set; }
        public string diesel { get; set; }
        public string gasoline { get; set; }
        public string country { get; set; }
    }
}
