using Luxury.DtoLayer.Dtos.MarketDataDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class LuxuryMarketsectionWeather : ViewComponent
    {
        public IViewComponentResult Invoke(List<WeatherDto> weather)
        {
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryMarketsectionWeather.cshtml", weather);
        }
    }
}
