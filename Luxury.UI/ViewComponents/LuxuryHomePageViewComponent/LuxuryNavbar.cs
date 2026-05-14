using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class LuxuryNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryNavbar.cshtml");
        }
    }
}
