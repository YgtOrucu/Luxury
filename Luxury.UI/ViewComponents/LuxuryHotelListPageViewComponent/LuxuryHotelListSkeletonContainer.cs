using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHotelListPageViewComponent
{
    public class LuxuryHotelListSkeletonContainer : ViewComponent
    {
        public IViewComponentResult Invoke(ResultHotelDto firstHotel , int ModelCount)
        {
            ViewBag.Count = ModelCount;
            return View("~/Views/Shared/Components/LuxuryHotelListPageViewComponent/LuxuryHotelListSkeletonContainer.cshtml", firstHotel);
        }
    }
}
