using AutoMapper;
using Luxury.BusinessLayer.Abstract;
using Luxury.DtoLayer.Dtos.TopFiveDestinationDto;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopFiveDestinationController : ControllerBase
    {
        private readonly ITopFiveDestinationsService _topFiveDestinationsService;
        private readonly IMapper _mapper;

        public TopFiveDestinationController(ITopFiveDestinationsService topFiveDestinationsService, IMapper mapper)
        {
            _topFiveDestinationsService = topFiveDestinationsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var destinations = await _topFiveDestinationsService.GetApiResponseAsync();
            return Ok(destinations != null ? _mapper.Map<List<TopFiveDestinationsDto>>(destinations.destinations) : new List<TopFiveDestinationsDto>());
        }
    }
}
