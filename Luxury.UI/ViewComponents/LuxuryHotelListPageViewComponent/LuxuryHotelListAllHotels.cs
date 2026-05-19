using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHotelListPageViewComponent
{
    public class LuxuryHotelListAllHotels : ViewComponent
    {
        public IViewComponentResult Invoke(List<ResultHotelDto> AllHotel)
        {
            return View("~/Views/Shared/Components/LuxuryHotelListPageViewComponent/LuxuryHotelListAllHotels.cshtml", AllHotel);
        }
    }
}
