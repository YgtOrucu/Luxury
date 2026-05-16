using Luxury.BusinessLayer.Models.RapidApi;

namespace Luxury.BusinessLayer.Abstract
{
    public interface ITopFiveDestinationsService
    {
        Task<TopFiveDestinationsResponse> GetApiResponseAsync();
    }
}
