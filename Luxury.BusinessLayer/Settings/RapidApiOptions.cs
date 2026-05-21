namespace Luxury.BusinessLayer.Settings
{
    public class RapidApiOptions
    {
        public string ApiKey { get; set; }
        public ServiceOptions Services { get; set; }
    }

    public class ServiceOptions
    {
        public ApiService Currency { get; set; }
        public ApiService Weather { get; set; }
        public ApiService Crypto { get; set; }
        public ApiService Fuel { get; set; }
        public ApiService TopFiveDestinations { get; set; }
        public ApiService GetIdByCityName { get; set; }
        public ApiService GetHotelByParameters { get; set; }
        public ApiService GetHotelDetailsById { get; set; }
    }

    public class ApiService
    {
        public string BaseUrl { get; set; }
        public string Host { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        public string ExchangeRate { get; set; }
        public string City { get; set; }
        public string MiniPrices { get; set; }
        public string EuropaCountry { get; set; }
        public string TopDestination { get; set; }
        public string GetDestination { get; set; }
        public string GetAllHotelByParameters { get; set; }
        public string GetHotelDetailById { get; set; }
    }
}
