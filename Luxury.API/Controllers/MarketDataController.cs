using Luxury.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketDataController : ControllerBase
    {
       private readonly IMarketDataService _marketDataService;

        public MarketDataController(IMarketDataService marketDataService)
        {
            _marketDataService = marketDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var currency = await _marketDataService.GetMarkerDataAsync();
            return Ok(currency);
        }
    }
}
