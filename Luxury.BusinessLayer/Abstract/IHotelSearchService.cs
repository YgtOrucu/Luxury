using Luxury.BusinessLayer.Models.RapidApi;

namespace Luxury.BusinessLayer.Abstract
{
    public interface IHotelSearchService
    {
        Task<string> GetIdByCityNameAsync(string cityname);
        Task<GetHotelByParametersApiResponse> GetHotelByParameters(string id, string checkIn, string checkOut, int adults, string children,
            int rooms, string units, string currencyCode, string Language, string temperature);
    }
}
