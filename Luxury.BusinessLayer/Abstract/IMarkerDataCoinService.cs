using Luxury.BusinessLayer.Models.RapidApi;

namespace Luxury.BusinessLayer.Abstract
{
    public interface IMarkerDataCoinService
    {
        Task<CryptoApiResponse> GetApiResponseAsync();
    }
}
