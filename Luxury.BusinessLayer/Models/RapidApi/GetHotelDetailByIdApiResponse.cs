namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class GetHotelDetailByIdApiResponse
    {
        public HotelDetailsInform data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class HotelDetailsInform
    {
        public int hotel_id { get; set; }
        public string hotel_name { get; set; }
        public string city { get; set; }
        public string country_trans { get; set; }
        public string hotel_address_line { get; set; }
        public string address { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string url { get; set; }
        public int review_nr { get; set; }
        public int is_preferred { get; set; }
        public string currency_code { get; set; }
        public string arrival_date { get; set; }
        public string departure_date { get; set; }
        public Facilities_Block facilities_block { get; set; }
        public Room_recommendation[] room_recommendation { get; set; }
        public Top_Ufi_Benefits[] top_ufi_benefits { get; set; }
        public string[] family_facilities { get; set; }
        public Composite_Price_Breakdown composite_price_breakdown { get; set; }
        public Block[] block { get; set; }
        public Chain[] chains { get; set; }
        public Dictionary<string, RoomDetail> rooms { get; set; }

        public class RoomDetail
        {
            public string description { get; set; }
            public Photo[] photos { get; set; }
            public Bed_Configurations[] bed_configurations { get; set; }
            public Highlight[] highlights { get; set; }
            public Facility[] facilities { get; set; }
            public Children_And_Beds_Text children_and_beds_text { get; set; }
        }
    }

    public class Facilities_Block
    {
        public string name { get; set; }
        public Facility[] facilities { get; set; }
    }

    public class Facility
    {
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class Top_Ufi_Benefits
    {
        public string translated_name { get; set; }
        public string icon { get; set; }
    }

    public class Room_recommendation
    {
        public int adults { get; set; }
        public int children { get; set; }
        public int babies { get; set; }
    }

    public class Composite_Price_Breakdown
    {
        public Gross_Amount gross_amount { get; set; }
        public Gross_Amount_Per_Night gross_amount_per_night { get; set; }
        public Excluded_Amount excluded_amount { get; set; }
        public All_Inclusive_Amount all_inclusive_amount { get; set; }
        public Included_Taxes_And_Charges_Amount included_taxes_and_charges_amount { get; set; }
        public Charges_Details charges_details { get; set; }

        public Item[] items { get; set; }
    }

    public class Gross_Amount
    {
        public float value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }
    public class Gross_Amount_Per_Night : Gross_Amount { }
    public class Excluded_Amount : Gross_Amount { }
    public class All_Inclusive_Amount : Gross_Amount { }
    public class Included_Taxes_And_Charges_Amount : Gross_Amount { }

    public class Charges_Details
    {
        public Amount amount { get; set; }
        public string mode { get; set; }
        public string translated_copy { get; set; }
    }

    public class Amount
    {
        public float value { get; set; }
        public string currency { get; set; }
    }
    public class Item
    {
        public string name { get; set; }
        public string inclusion_type { get; set; }
        public string kind { get; set; }
        public string details { get; set; }

        public Base base_value { get; set; }
        public Item_Amount item_amount { get; set; }
    }

    public class Base
    {
        public string kind { get; set; }
        public float percentage { get; set; }
        public float base_amount { get; set; }
    }
    public class Item_Amount
    {
        public float value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
    }
    public class Photo
    {
        public string url_original { get; set; }
        public string url_max300 { get; set; }
    }

    public class Bed_Configurations
    {
        public Bed_Types[] bed_types { get; set; }
    }

    public class Bed_Types
    {
        public int count { get; set; }
        public string name_with_count { get; set; }
    }

    public class Highlight
    {
        public string translated_name { get; set; }
        public string icon { get; set; }
    }

    public class Facility1
    {
        public string name { get; set; }
    }

    public class Children_And_Beds_Text
    {
        public Children_At_The_Property[] children_at_the_property { get; set; }
        public Cribs_And_Extra_Beds[] cribs_and_extra_beds { get; set; }
    }

    public class Children_At_The_Property
    {
        public string text { get; set; }
    }

    public class Cribs_And_Extra_Beds
    {
        public string text { get; set; }
    }

    public class Block
    {
        public string mealplan { get; set; }

        public Product_Price_Breakdown product_price_breakdown { get; set; }

        public Paymentterms paymentterms { get; set; }

        public string name { get; set; }
        public string room_name { get; set; }

        public int room_surface_in_m2 { get; set; }
        public float room_surface_in_feet2 { get; set; }

        public int breakfast_included { get; set; }
        public int refundable { get; set; }

        public string block_id { get; set; }
        public int roomtype_id { get; set; }

        public int nr_adults { get; set; }
        public int nr_children { get; set; }

        public int[] children_ages { get; set; }

        public string mealplan_vector { get; set; }

        public Detail_Mealplan[] detail_mealplan { get; set; }
    }

    public class Product_Price_Breakdown
    {
        public Gross_Amount1 gross_amount { get; set; }
        public Gross_Amount_Per_Night1 gross_amount_per_night { get; set; }
        public All_Inclusive_Amount1 all_inclusive_amount { get; set; }
    }

    public class Gross_Amount1
    {
        public float value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }

    public class Gross_Amount_Per_Night1
    {
        public float value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }

    public class All_Inclusive_Amount1
    {
        public float value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }

    public class Paymentterms
    {
        public Cancellation cancellation { get; set; }
        public Prepayment prepayment { get; set; }
    }

    public class Cancellation
    {
        public string description { get; set; }
        public string type_translation { get; set; }
        public Timeline timeline { get; set; }
    }

    public class Prepayment
    {
        public string description { get; set; }
        public string simple_translation { get; set; }
        public string extended_type_translation { get; set; }
        public Timeline timeline { get; set; }
    }

    public class Timeline
    {
        public Stage[] stages { get; set; }
    }

    public class Stage
    {
        public float fee { get; set; }
        public string text { get; set; }
    }

    public class Detail_Mealplan
    {
        public string title { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; }
    }

    public class Chain
    {
        public string logo { get; set; }
        public string name { get; set; }
    }
}