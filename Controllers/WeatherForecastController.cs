using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace aspnet_core_localization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "FREEZING", "BRACING", "CHILLY", "COOL", "MILD", "WARM", "HOT", "SWELTERING", "SCORCHING"
        };

        private readonly IStringLocalizer<SharedResource> _localizer;

        public WeatherForecastController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),

                TemperatureC = rng.Next(-20, 55),

                Summary = _localizer[Summaries[rng.Next(Summaries.Length)]]

            }).ToArray();
        }
    }
}
