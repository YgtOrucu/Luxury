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
