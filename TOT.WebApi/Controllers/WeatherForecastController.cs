using Microsoft.AspNetCore.Mvc;
using TOT.DTO;
using TOT.Services.Caching.Interfaces;

namespace TOT.WebApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    //[EnableRateLimiting("fixed")]
    public class WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        TotContext dbContext)
        : ControllerBase
    {
        [HttpGet("Setup/{value}")]
        public async Task Set(string value, [FromServices] ICachingService cachingService, CancellationToken token)
        {
            await cachingService.SetAsync("test", value, token);
        }

        [HttpGet("Choppe/{key}")]
        public async Task<ActionResult<string>> Get(string key, [FromServices] ICachingService cachingService, CancellationToken token)
        {
            var value = await cachingService.GetAsync<string>(key, token);
            return new ActionResult<string>(value);
        }
    }
}
