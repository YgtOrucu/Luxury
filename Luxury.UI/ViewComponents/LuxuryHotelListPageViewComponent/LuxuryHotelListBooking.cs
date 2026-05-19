using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHotelListPageViewComponent
{
    public class LuxuryHotelListBooking : ViewComponent
    {
        public IViewComponentResult Invoke(ResultHotelDto firstHotel, int? adults, int? rooms, int? children)
        {
            ViewBag.Adults = adults;
            ViewBag.Rooms = rooms;
            ViewBag.Children = children;

            return View("~/Views/Shared/Components/LuxuryHotelListPageViewComponent/LuxuryHotelListBooking.cshtml", firstHotel);
        }
    }
}
