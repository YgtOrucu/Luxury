using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class LuxuryDestinations : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryDestinations.cshtml");
        }
    }
}
