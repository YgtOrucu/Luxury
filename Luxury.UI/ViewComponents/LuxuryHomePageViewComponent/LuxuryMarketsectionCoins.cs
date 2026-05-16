using Luxury.DtoLayer.Dtos.MarketDataDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class LuxuryMarketsectionCoins : ViewComponent
    {
        public IViewComponentResult Invoke(List<CryptoDto> Coins)
        {
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryMarketsectionCoins.cshtml", Coins);
        }
    }
}
