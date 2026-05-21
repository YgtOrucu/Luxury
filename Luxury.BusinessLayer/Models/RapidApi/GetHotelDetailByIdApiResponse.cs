namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class GetHotelDetailByIdApiResponse
    {
        public GetHotelDetails data { get; set; }
    }

    public class GetHotelDetails
    {
        public string hotel_name { get; set; }
        public string description { get; set; }
        public string accommodation_type_name { get; set; }
        public string city { get; set; }
        public string country_trans { get; set; }
        public string address { get; set; }
        public string timezone { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public double distance_to_cc { get; set; } // DistanceToCenter için
        public int review_nr { get; set; }        // ReviewCount için
        public int available_rooms { get; set; }
        public int is_family_friendly { get; set; }

        public string[] spoken_languages { get; set; }
        public string[] family_facilities { get; set; }

        // Listeler ve Alt Bloklar
        public Top_Ufi_Benefits[] top_ufi_benefits { get; set; }
        public Facilities_Block facilities_block { get; set; }
        public Rooms rooms { get; set; }
        public Block[] block { get; set; } // İptal politikası açıklaması çekmek için tutuldu
        public Composite_Price_Breakdown composite_price_breakdown { get; set; }
    }

    public class Block
    {
        public PaymentTerms? paymentterms { get; set; }
        public Bundleextras? bundle_extras { get; set; }
    }

    public class PaymentTerms
    {
        public Cancellation cancellation { get; set; }
        public Prepayment prepayment { get; set; }

    }

    public class Bundleextras
    {
        public string highlighted_text { get; set; }

    }

    public class Cancellation
    {
        public string description { get; set; } // CancellationDescription için
        public string type_translation { get; set; }
    }
    public class Prepayment
    {
        public string simple_translation { get; set; } // CancellationDescription için
    }

    public class Top_Ufi_Benefits
    {
        public string translated_name { get; set; } // TopBenefits için
    }

    public class Rooms
    {
        public Dictionary<string, RoomDetail>? room_map { get; set; }
    }

    public class RoomDetail
    {
        public List<RoomPhoto> photos { get; set; }
    }

    public class RoomPhoto
    {
        public string url_original { get; set; } // GalleryPhotos ve RoomPhotos için
    }

    public class Facilities_Block
    {
        public Facility[] facilities { get; set; }
    }

    public class Facility
    {
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class Composite_Price_Breakdown
    {
        public Gross_Amount gross_amount { get; set; }
        public Gross_Amount_Per_Night gross_amount_per_night { get; set; }
    }

    public class Gross_Amount
    {
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }

    public class Gross_Amount_Per_Night
    {
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }
}