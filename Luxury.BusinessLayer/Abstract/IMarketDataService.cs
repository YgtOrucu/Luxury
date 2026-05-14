using Luxury.DtoLayer.Dtos.MarketDataDtos;

namespace Luxury.BusinessLayer.Abstract
{
    public interface IMarketDataService
    {
        Task<MarketDataDto> GetMarkerDataAsync();
    }
}
