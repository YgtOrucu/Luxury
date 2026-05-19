namespace Luxury.DtoLayer.Dtos.HotelSearchDtos
{
    public class HotelSearchFormDto
    {
        public string City { get; set; }
        public string CheckIn { get; set; } 
        public string CheckOut { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int DefaultAge { get; set; } = 1;
        public int Rooms { get; set; }
        public string Units { get; set; } = "metric";
        public string CurrencyCode { get; set; } = "TRY";
        public string Temperature { get; set; } = "c";
        public string Language { get; set; } = "tr-tr";
    }
}
