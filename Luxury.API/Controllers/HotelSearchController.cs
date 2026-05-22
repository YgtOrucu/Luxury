using AutoMapper;
using Luxury.BusinessLayer.Abstract;
using Luxury.DtoLayer.Dtos.HotelSearchDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelSearchController : ControllerBase
    {
        private readonly IHotelSearchService _hotelservice;
        private readonly IMapper _mapper;

        public HotelSearchController(IHotelSearchService hotelservice, IMapper mapper)
        {
            _hotelservice = hotelservice;
            _mapper = mapper;
        }

        [HttpGet("GetIdByCityName")]
        public async Task<IActionResult> Get(string cityname)
        {
            var id = await _hotelservice.GetIdByCityNameAsync(cityname);
            if (id != null) return Ok(id);
            return Ok(null);
        }

        [HttpGet("GetHotelByParametres")]
        public async Task<IActionResult> GetHotel(string id, string CheckIn, string CheckOut, int Adults,
            int Rooms, string Units, string CurrencyCode, string Language, string Temperature, string? Children = null)
        {
            var values = await _hotelservice.GetHotelByParameters(id, CheckIn, CheckOut, Adults, Children, Rooms, Units, CurrencyCode, Language, Temperature);
            if (values != null)
                return Ok(_mapper.Map<List<ResultHotelDto>>(values.data));
            return Ok(null);
        }

        [HttpGet("GetHotelDetailById")]
        public async Task<IActionResult> Details(int hotelId, string checkInDate, string checkOutDate, int rooms,
           int adults, string units, string currencyCode, string language, string? children = null)
        {
            var values = await _hotelservice.GetHotelDetailsById(hotelId, checkInDate, checkOutDate, rooms, adults, units, currencyCode, language, children);
             if (values != null)
                return Ok(_mapper.Map<HotelDetailDto>(values.data));
            return Ok(null);
        }
    }
}
