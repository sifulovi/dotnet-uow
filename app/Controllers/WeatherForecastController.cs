using System.Collections.Generic;
using app.Contracts.Repos.WrapperRepo;
using app.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            var account = _repositoryWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owner = _repositoryWrapper.Owner.FindAll();

                return owner;
        }
    }
}