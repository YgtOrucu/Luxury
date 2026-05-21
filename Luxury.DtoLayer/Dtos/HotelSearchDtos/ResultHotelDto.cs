namespace Luxury.DtoLayer.Dtos.HotelSearchDtos
{
    public class ResultHotelDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int PropertyClass { get; set; }
        public int ReviewCount { get; set; }
        public string ReviewScore { get; set; }
        public string ReviewScoreWord { get; set; } 
        public string MainPhotoUrl { get; set; }
        public string CheckinDate { get; set; }
        public string CheckoutDate { get; set; }
        public string AmountRounded { get; set; }
        public string WishlistName { get; set; }
        public string Units { get; set; } = "metric";
        public string CurrencyCode { get; set; } = "TRY";
        public string Language { get; set; } = "tr-tr";
    }
}
