using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;
using System.Security.Cryptography.X509Certificates;
namespace HospitalApi.Controllers
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
        db_hospitalContext db_hospitalContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            db_hospitalContext = new db_hospitalContext();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<TbAppointment> Get()
        {
            
            return db_hospitalContext.TbAppointments.ToList();
        }
    }
}
