using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHotelListPageViewComponent
{
    public class LuxuryHotelListAllHotels : ViewComponent
    {
        public IViewComponentResult Invoke(List<ResultHotelDto> AllHotel , int? adults, int? rooms, int? children)
        {
            ViewBag.Adults = adults;
            ViewBag.Rooms = rooms;
            ViewBag.Children = children;
            return View("~/Views/Shared/Components/LuxuryHotelListPageViewComponent/LuxuryHotelListAllHotels.cshtml", AllHotel);
        }
    }
}
