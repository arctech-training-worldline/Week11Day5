using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Week11Day5.Services;

namespace Week11Day5.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        // GET: WeatherForcastController
        public async Task<ActionResult> IndexAsync()
        {
            var fullForecast = await _weatherForecastService.GetFullForecastAsync("mumbai");
            return View(fullForecast);
        }
    }
}
