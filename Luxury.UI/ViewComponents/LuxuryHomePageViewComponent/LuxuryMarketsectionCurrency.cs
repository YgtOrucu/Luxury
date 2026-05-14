using Luxury.DtoLayer.Dtos.MarketDataDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class LuxuryMarketsectionCurrency : ViewComponent
    {
        public IViewComponentResult Invoke(List<CurrencyDto> currency)
        {
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryMarketsectionCurrency.cshtml", currency);
        }
    }
}
