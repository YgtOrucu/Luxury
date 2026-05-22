namespace Luxury.DtoLayer.Dtos.HotelSearchDtos
{
    public class HotelDetailDto
    {
        public int hotel_id { get; set; }
        public string hotel_name { get; set; }
        public string city { get; set; }
        public string country_trans { get; set; }
        public string hotel_address_line { get; set; }
        public string address { get; set; }

        public double latitude { get; set; }
        public double longitude { get; set; }

        public string url { get; set; }
        public int review_nr { get; set; }
        public int is_preferred { get; set; }
        public string currency_code { get; set; }
        public string arrival_date { get; set; }
        public string departure_date { get; set; }

        public FacilitiesBlockDto facilities_block { get; set; }
        public TopUfiBenefitDto[] top_ufi_benefits { get; set; }
        public RoomRecommendationDto[] room_recommendation { get; set; }
        public string[] family_facilities { get; set; }

        public CompositePriceBreakdownDto composite_price_breakdown { get; set; }

        public Dictionary<string, RoomDetailDto> rooms { get; set; }

        public BlockDto[] block { get; set; }
        public ChainDto[] chains { get; set; }
    }

    // ===================== FACILITIES =====================

    public class FacilitiesBlockDto
    {
        public string name { get; set; }
        public FacilityDto[] facilities { get; set; }
    }
    public class RoomRecommendationDto
    {
        public int children { get; set; }
        public int adults { get; set; }
        public int babies { get; set; }
    }

    public class FacilityDto
    {
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class TopUfiBenefitDto
    {
        public string translated_name { get; set; }
        public string icon { get; set; }
    }

    // ===================== PRICE =====================

    public class CompositePriceBreakdownDto
    {
        public MoneyDto gross_amount { get; set; }
        public MoneyDto gross_amount_per_night { get; set; }
        public MoneyDto excluded_amount { get; set; }
        public MoneyDto all_inclusive_amount { get; set; }

        public MoneyDto included_taxes_and_charges_amount { get; set; }
        public ChargesDetailsDto charges_details { get; set; }

        public ItemDto[] items { get; set; }
    }

    public class MoneyDto
    {
        public decimal value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }

    public class ChargesDetailsDto
    {
        public MoneyDto amount { get; set; }
        public string mode { get; set; }
    }

    public class ItemDto
    {
        public string name { get; set; }
        public string inclusion_type { get; set; }
        public string kind { get; set; }
        public string details { get; set; }

        public BaseDto base_value { get; set; }
        public MoneyDto item_amount { get; set; }
    }

    public class BaseDto
    {
        public string kind { get; set; }
        public decimal percentage { get; set; }
        public decimal base_amount { get; set; }
    }

    // ===================== ROOM =====================

    public class RoomDetailDto
    {
        public string description { get; set; }
        public PhotoDto[] photos { get; set; }

        public BedConfigurationDto[] bed_configurations { get; set; }
        public HighlightDto[] highlights { get; set; }

        public FacilityDto[] facilities { get; set; }

        public ChildrenBedsDto children_and_beds_text { get; set; }
    }

    public class PhotoDto
    {
        public string url_original { get; set; }
        public string url_max300 { get; set; }
    }

    public class BedConfigurationDto
    {
        public BedTypeDto[] bed_types { get; set; }
    }

    public class BedTypeDto
    {
        public int count { get; set; }
        public string name_with_count { get; set; }
    }

    public class HighlightDto
    {
        public string translated_name { get; set; }
        public string icon { get; set; }
    }

    public class ChildrenBedsDto
    {
        public ChildrenAtPropertyDto[] children_at_the_property { get; set; }
        public CribsDto[] cribs_and_extra_beds { get; set; }
    }

    public class ChildrenAtPropertyDto
    {
        public string text { get; set; }
    }

    public class CribsDto
    {
        public string text { get; set; }
    }

    // ===================== BLOCK =====================

    public class BlockDto
    {
        public string mealplan { get; set; }
        public ProductPriceBreakdownDto product_price_breakdown { get; set; }
        public PaymentTermsDto paymentterms { get; set; }

        public string name { get; set; }
        public string room_name { get; set; }

        public int room_surface_in_m2 { get; set; }
        public double room_surface_in_feet2 { get; set; }

        public int breakfast_included { get; set; }
        public int refundable { get; set; }

        public int roomtype_id { get; set; }
        public string block_id { get; set; }

        public int nr_adults { get; set; }
        public int nr_children { get; set; }

        public int[] children_ages { get; set; }

        public DetailMealPlanDto[] detail_mealplan { get; set; }
    }

    public class ProductPriceBreakdownDto
    {
        public MoneyDto gross_amount { get; set; }
        public MoneyDto gross_amount_per_night { get; set; }
        public MoneyDto all_inclusive_amount { get; set; }
    }

    public class PaymentTermsDto
    {
        public CancellationDto cancellation { get; set; }
        public PrepaymentDto prepayment { get; set; }
    }

    public class CancellationDto
    {
        public string description { get; set; }
        public string type_translation { get; set; }
    }

    public class PrepaymentDto
    {
        public string description { get; set; }
        public string simple_translation { get; set; }
        public string extended_type_translation { get; set; }
    }

    public class DetailMealPlanDto
    {
        public string title { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; }
    }

    // ===================== CHAIN =====================

    public class ChainDto
    {
        public string logo { get; set; }
        public string name { get; set; }
    }
}