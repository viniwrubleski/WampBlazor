using WampBlazor.Shared;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WampBlazor.Shared.Services;
using System.Threading.Tasks;

namespace WampBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _service.Get();
        }
    }
}
