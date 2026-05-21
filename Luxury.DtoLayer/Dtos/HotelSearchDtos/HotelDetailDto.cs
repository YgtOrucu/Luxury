namespace Luxury.DtoLayer.Dtos.HotelSearchDtos
{
    public class HotelDetailDto
    {
        // Temel Bilgiler
        public string HotelName { get; set; }
        public string Description { get; set; }
        public string AccommodationTypeName { get; set; }
        public string City { get; set; }
        public string CountryTrans { get; set; }
        public string Address { get; set; }
        public string Timezone { get; set; }

        // Metrikler & Sayılar
        public double DistanceToCenter { get; set; }
        public int ReviewCount { get; set; }
        public int AvailableRooms { get; set; }
        public bool IsFamilyFriendly { get; set; }

        // Orijinal Para Birimi Fiyatları
        public string Currency { get; set; }
        public string GrossAmountPerNight { get; set; }
        public string GrossAmount { get; set; }

        // Koleksiyonlar (Listeler)
        public List<HotelPhotoDto> GalleryPhotos { get; set; } = new List<HotelPhotoDto>();
        public List<HotelPhotoDto> RoomPhotos { get; set; } = new List<HotelPhotoDto>();
        public List<HotelFacilityDto> Facilities { get; set; } = new List<HotelFacilityDto>();
        public string[] SpokenLanguages { get; set; }
        public string[] TopBenefits { get; set; }
        public string[] FamilyFacilities { get; set; }

        // Politikalar
        public string CancellationDescription { get; set; }

        // Harita için Koordinatlar
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public string PrepaymentText { get; set; }     // "Ön ödeme yok"
        public string CancellationType { get; set; }   // "Kısmen iade edilebilir"
        public string HighlightedBenefit { get; set; } // "Dahil: yüksek hızlı internet"
    }

    // HTML içinde döngüye soktuğun fotoğraf alt yapısı
    public class HotelPhotoDto
    {
        public string Url { get; set; }
    }

    // HTML içindeki <i class="bi bi-@facility.Icon"></i> ve Name yapısı
    public class HotelFacilityDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}