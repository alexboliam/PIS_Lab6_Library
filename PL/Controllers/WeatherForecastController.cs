using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PL.Controllers
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
        private IBooksService booksService;
        private IStudentsService studentsService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBooksService booksService, IStudentsService studentsService)
        {
            _logger = logger;
            this.booksService = booksService;
            this.studentsService = studentsService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var res = this.booksService.GetBooksByAuthorName("Rowling").ToList();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
