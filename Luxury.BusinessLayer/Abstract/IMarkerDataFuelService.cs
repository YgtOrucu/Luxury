using Luxury.BusinessLayer.Models.RapidApi;

namespace Luxury.BusinessLayer.Abstract
{
    public interface IMarkerDataFuelService
    {
        Task<FuelApiResponse> GetFuelPrices();
    }
}
