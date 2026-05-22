using AutoMapper;
using Luxury.BusinessLayer.Models.RapidApi;
using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Luxury.DtoLayer.Dtos.MarketDataDtos;
using Luxury.DtoLayer.Dtos.TopFiveDestinationDto;


namespace Luxury.BusinessLayer.Mapping.MapProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CryptoResult, CryptoDto>().ReverseMap();
            CreateMap<Datum, CurrencyDto>().ReverseMap();

            CreateMap<Result, FuelDto>()
                .ForMember(dest => dest.gasoline, opt => opt.MapFrom(src => ConvertFuelPrice(src.gasoline)))
                .ForMember(dest => dest.diesel, opt => opt.MapFrom(src => ConvertFuelPrice(src.diesel)))
                .ForMember(dest => dest.lpg, opt => opt.MapFrom(src => ConvertFuelPrice(src.lpg)));


            CreateMap<WeatherApiResponse, WeatherDto>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => (int)Math.Round((src.main.temp - 32) * 5 / 9)))
                .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.visibility / 1000))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.main.humidity))
                .ForMember(dest => dest.Wind, opt => opt.MapFrom(src => (int)src.wind.speed))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.weather[0].main))
                .ForMember(dest => dest.WeatherIcon, opt => opt.MapFrom(src => src.weather != null && src.weather.Count > 0 ?
                GetEmojiIcon(src.weather[0].main) : "🌍"));


            CreateMap<Destination, TopFiveDestinationsDto>()
               .ForMember(dest => dest.averagePrice, opt => opt.MapFrom(src =>
                src.averagePrice > 0 ? Math.Round((src.averagePrice / 500) * 5, 1) : 0));

            CreateMap<AllHotel, ResultHotelDto>()
                .ForMember(desc => desc.MainPhotoUrl, opt => opt.MapFrom(src => (src.photoUrls != null && src.photoUrls.Length > 0 && !string.IsNullOrEmpty(src.photoUrls[0]))
                           ? src.photoUrls[0].Replace("square60", "max430")
                           : null))
                .ForMember(desc => desc.AmountRounded, opt => opt.MapFrom(src => src.priceBreakdown.grossPrice.amountRounded))
                .ForMember(desc => desc.ReviewScore, opt => opt.MapFrom(src => src.reviewScore.ToString("0.0")));


            CreateMap<HotelDetailsInform, HotelDetailDto>();
            CreateMap<Facilities_Block, FacilitiesBlockDto>();
            CreateMap<Facility, FacilityDto>();
            CreateMap<Top_Ufi_Benefits, TopUfiBenefitDto>();
            CreateMap<Gross_Amount, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<Gross_Amount_Per_Night, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<Excluded_Amount, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<All_Inclusive_Amount, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<Included_Taxes_And_Charges_Amount, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<Amount, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value)).ForMember(d => d.amount_rounded, o => o.Ignore());
            CreateMap<Item_Amount, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<Gross_Amount1, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<Gross_Amount_Per_Night1, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<All_Inclusive_Amount1, MoneyDto>().ForMember(d => d.value, o => o.MapFrom(s => (decimal)s.value));
            CreateMap<Composite_Price_Breakdown, CompositePriceBreakdownDto>();
            CreateMap<Charges_Details, ChargesDetailsDto>();
            CreateMap<Item, ItemDto>();
            CreateMap<Base, BaseDto>()
                .ForMember(d => d.percentage, o => o.MapFrom(s => (decimal)s.percentage))
                .ForMember(d => d.base_amount, o => o.MapFrom(s => (decimal)s.base_amount));

            CreateMap<HotelDetailsInform.RoomDetail, RoomDetailDto>();
            CreateMap<Room_recommendation, RoomRecommendationDto>();
            CreateMap<Photo, PhotoDto>()
                .ForMember(d => d.url_original, o => o.MapFrom(s => s.url_original != null ? s.url_original.Replace("max500", "max1200") : null))
                .ForMember(d => d.url_max300,o => o.MapFrom(s =>s.url_max300 != null? s.url_max300.Replace("max300", "max800"): null));

            CreateMap<Bed_Configurations, BedConfigurationDto>();
            CreateMap<Bed_Types, BedTypeDto>();
            CreateMap<Highlight, HighlightDto>();
            CreateMap<Facility1, FacilityDto>().ForMember(d => d.icon, o => o.Ignore());
            CreateMap<Children_And_Beds_Text, ChildrenBedsDto>();
            CreateMap<Children_At_The_Property, ChildrenAtPropertyDto>();
            CreateMap<Cribs_And_Extra_Beds, CribsDto>();
            CreateMap<Block, BlockDto>()
                .ForMember(d => d.room_surface_in_feet2, o => o.MapFrom(s => (double)s.room_surface_in_feet2));

            CreateMap<Product_Price_Breakdown, ProductPriceBreakdownDto>();
            CreateMap<Paymentterms, PaymentTermsDto>();
            CreateMap<Cancellation, CancellationDto>();
            CreateMap<Prepayment, PrepaymentDto>();
            CreateMap<Detail_Mealplan, DetailMealPlanDto>()
                .ForMember(d => d.price, o => o.MapFrom(s => s.price));

            CreateMap<Chain, ChainDto>();
            CreateMap<Dictionary<string, HotelDetailsInform.RoomDetail>, Dictionary<string, RoomDetailDto>>()
                .ConvertUsing((src, dest, context) =>
                {
                    if (src == null)
                        return new Dictionary<string, RoomDetailDto>();

                    return src.ToDictionary(
                        x => x.Key,
                        x => context.Mapper.Map<RoomDetailDto>(x.Value)
                    );
                });
        }

        private string GetEmojiIcon(string weatherMain)
        {
            return weatherMain switch
            {
                "Clear" => "☀️",
                "Clouds" => "☁️",
                "Rain" => "🌧️",
                "Drizzle" => "🌦️",
                "Thunderstorm" => "⛈️",
                "Snow" => "❄️",
                "Mist" or "Fog" or "Haze" => "🌫️",
                _ => "🌍"
            };
        }
        private decimal ConvertFuelPrice(string source)
        {
            return decimal.TryParse(source, out var value) ? value * 53 : 0;
        }
    }
}
