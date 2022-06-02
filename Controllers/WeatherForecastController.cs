using Microsoft.AspNetCore.Mvc;

namespace WeatherApp2.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        /*[HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 50).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        }
        */


        [HttpGet("test")]
        public IEnumerable<jklWeather> GetTest([FromQuery] string City, [FromQuery] string code)
        {
            Console.WriteLine(City);
            Console.WriteLine(code);
            var dataReturner = new WeatherDataClass();
            var dataArray = dataReturner.Main(City, code);

            return Enumerable.Range(1, 1).Select(index => new jklWeather
            {
                date = dataArray[0],
                temp = dataArray[1],
                desc = dataArray[2]
            })
            .ToArray();
        }
    }
}