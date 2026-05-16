using Luxury.DtoLayer.Dtos.MarketDataDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class LuxuryMarketsectionWeather : ViewComponent
    {
        public IViewComponentResult Invoke(List<WeatherDto> Weather)
        {
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryMarketsectionWeather.cshtml", Weather);
        }
    }
}
