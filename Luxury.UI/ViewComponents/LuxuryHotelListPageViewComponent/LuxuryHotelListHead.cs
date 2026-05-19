using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHotelListPageViewComponent
{
    public class LuxuryHotelListHead : ViewComponent
    {
        public IViewComponentResult Invoke(string currentCity)
        {
            return View("~/Views/Shared/Components/LuxuryHotelListPageViewComponent/LuxuryHotelListHead.cshtml", currentCity);
        }
    }
}
