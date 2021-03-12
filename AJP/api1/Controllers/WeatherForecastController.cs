using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api1.Controllers
{
    [ApiController]

    public class WeatherForecastController : ControllerBase
    {



        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/wather")]
        [Produces("application/xml")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("api/weather")]
        //[Produces("application/xml")]
        //[Consumes("application/xml")]
        public WeatherForecast AddNew([FromBody] WeatherForecast f)
        {
            System.Console.WriteLine($"Przysło : {f.Date} !");
            return f;


        }

        public class Czlowiek
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }



        }
    }
}
