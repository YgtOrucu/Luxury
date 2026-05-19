using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHotelListPageViewComponent
{
    public class LuxuryHotelListNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/LuxuryHotelListPageViewComponent/LuxuryHotelListNavbar.cshtml");
        }
    }
}
