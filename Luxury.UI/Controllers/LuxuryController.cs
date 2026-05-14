using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.Controllers
{
    public class LuxuryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
