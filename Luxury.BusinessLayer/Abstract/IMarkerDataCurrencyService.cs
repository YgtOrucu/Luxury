using Luxury.BusinessLayer.Models.RapidApi;

namespace Luxury.BusinessLayer.Abstract
{
    public interface IMarkerDataCurrencyService
    {
        Task<CurrencyApiResponse> GetCurrencyRate();
    }
}
