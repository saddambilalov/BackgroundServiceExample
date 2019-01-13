using BackgroundService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRandomStringProvider _randomStringProvider;

        public ValuesController(IRandomStringProvider randomStringProvider)
        {
            _randomStringProvider = randomStringProvider;
        }

        [HttpGet]
        public string Get()
        {
            return _randomStringProvider.RandomString;
        }
    }
}
