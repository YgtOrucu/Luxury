namespace Luxury.BusinessLayer.Models.RapidApi
{
    namespace Luxury.BusinessLayer.Models.RapidApi
    {
        public class WeatherApiResponse
        {
            public string name { get; set; }
            public MainInfo main { get; set; }
            public WindInfo wind { get; set; }
            public List<WeatherInfo> weather { get; set; }
            public int visibility { get; set; }
        }

        public class MainInfo
        {
            public double temp { get; set; }
            public int humidity { get; set; }
        }

        public class WindInfo
        {
            public double speed { get; set; }
        }

        public class WeatherInfo
        {
            public string main { get; set; }
        }
    }
}
