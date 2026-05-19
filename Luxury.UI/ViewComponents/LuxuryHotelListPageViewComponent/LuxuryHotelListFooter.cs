using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHotelListPageViewComponent
{
    public class LuxuryHotelListFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/LuxuryHotelListPageViewComponent/LuxuryHotelListFooter.cshtml");
        }
    }
}
