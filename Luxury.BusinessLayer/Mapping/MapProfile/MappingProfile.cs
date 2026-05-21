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


            CreateMap<GetHotelDetails, HotelDetailDto>()
                            // API içindeki farklı isimdeki temel alanları eşleme
                            .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.hotel_name))
                            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                            .ForMember(dest => dest.AccommodationTypeName, opt => opt.MapFrom(src => src.accommodation_type_name))
                            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.city))
                            .ForMember(dest => dest.CountryTrans, opt => opt.MapFrom(src => src.country_trans))
                            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
                            .ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.timezone))

                            // Sayısal değerleri eşleme
                            .ForMember(dest => dest.DistanceToCenter, opt => opt.MapFrom(src => src.distance_to_cc))
                            .ForMember(dest => dest.ReviewCount, opt => opt.MapFrom(src => src.review_nr))
                            .ForMember(dest => dest.AvailableRooms, opt => opt.MapFrom(src => src.available_rooms))

                            // int (0/1) değerini bool değerine dönüştürme
                            .ForMember(dest => dest.IsFamilyFriendly, opt => opt.MapFrom(src => src.is_family_friendly == 1))

                            // Düz array ve listeleri eşleme
                            .ForMember(dest => dest.SpokenLanguages, opt => opt.MapFrom(src => src.spoken_languages))
                            .ForMember(dest => dest.FamilyFacilities, opt => opt.MapFrom(src => src.family_facilities))
                            .ForMember(dest => dest.TopBenefits, opt => opt.MapFrom(src => src.top_ufi_benefits.Select(x => x.translated_name).ToArray()))

                            .ForMember(dest => dest.PrepaymentText, opt => opt.MapFrom(src => src.block != null && src.block.Length > 0 ? src.block[0].paymentterms.prepayment.simple_translation : ""))
                            .ForMember(dest => dest.CancellationType, opt => opt.MapFrom(src => src.block != null && src.block.Length > 0 ? src.block[0].paymentterms.cancellation.type_translation : ""))
                            .ForMember(dest => dest.HighlightedBenefit, opt => opt.MapFrom(src => src.block != null && src.block.Length > 0 ? src.block[0].bundle_extras.highlighted_text : ""))

                            // Tesis ikonlarını ve isimlerini alt listeye map'leme
                            .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.facilities_block != null && src.facilities_block.facilities != null
                                ? src.facilities_block.facilities.Select(f => new HotelFacilityDto { Name = f.name, Icon = f.icon }).ToList()
                                : null))

                            // Fiyat bloklarını alt nesnelerden yukarı çekme
                            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.composite_price_breakdown.gross_amount.currency))
                            .ForMember(dest => dest.GrossAmount, opt => opt.MapFrom(src => src.composite_price_breakdown.gross_amount.amount_rounded))
                            .ForMember(dest => dest.GrossAmountPerNight, opt => opt.MapFrom(src => src.composite_price_breakdown.gross_amount_per_night.amount_rounded))

                            // İlk bloğun iptal politikasını çekme (Null kontrolü ile güvenli hale getirildi)
                            .ForMember(dest => dest.CancellationDescription, opt => opt.MapFrom(src => src.block != null && src.block.Length > 0
                                ? src.block[0].paymentterms.cancellation.description
                                : string.Empty))

                            // Dictionary (room_map) içindeki tüm fotoğrafları düz listelere (Gallery ve Room) çevirme
                            .ForMember(dest => dest.GalleryPhotos, opt => opt.MapFrom(src => src.rooms != null && src.rooms.room_map != null
                                ? src.rooms.room_map.Values
                                    .SelectMany(r => r.photos ?? new List<RoomPhoto>())
                                    .Select(p => new HotelPhotoDto { Url = p.url_original })
                                    .ToList()
                                : null))
                            .ForMember(dest => dest.RoomPhotos, opt => opt.MapFrom(src => src.rooms != null && src.rooms.room_map != null
                                ? src.rooms.room_map.Values
                                    .SelectMany(r => r.photos ?? new List<RoomPhoto>())
                                    .Select(p => new HotelPhotoDto { Url = p.url_original })
                                    .ToList()
                                : null))

                            // Harita Koordinatları
                            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.latitude))
                            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.longitude));

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
