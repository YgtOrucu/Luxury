using Luxury.DtoLayer.Dtos.TopFiveDestinationDto;
using Microsoft.AspNetCore.Mvc;

namespace Luxury.UI.ViewComponents.LuxuryHomePageViewComponent
{
    public class TopFiveDestinations : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TopFiveDestinations(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("LuxuryApi");
            var response = await client.GetAsync("TopFiveDestination");
            if (response.IsSuccessStatusCode)
            {
                var values = response != null ? await response.Content.ReadFromJsonAsync<List<TopFiveDestinationsDto>>() : null;
                return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/TopFiveDestinations.cshtml", values);
            }
            return View("~/Views/Shared/Components/LuxuryHomePageViewComponent/TopFiveDestinations.cshtml");
        }
    }
}
