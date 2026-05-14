using Luxury.DtoLayer.Dtos.MarketDataDtos;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class LuxuryMarketsection : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LuxuryMarketsection(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("LuxuryApi");
            var response = await client.GetAsync("MarketData");
            if (response.IsSuccessStatusCode)
            {
              var values = await response.Content.ReadFromJsonAsync<MarketDataDto>();
              return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryMarketsection.cshtml", values);
            }
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/LuxuryMarketsection.cshtml");
        }
    }
}
