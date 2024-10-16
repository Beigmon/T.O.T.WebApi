using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TOT.Models.Startgg.Stations;
using TOT.Services.ControllerServices.Interfaces;

namespace TOT.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [EnableRateLimiting("fixed")]
    public class StationController(ILogger<StationController> logger)
        : ControllerBase
    {
        [HttpGet("GetAll/{tournamentId}")]
        public async Task<ActionResult<List<Station>?>> GetPlayerAsync(int tournamentId, [FromServices] IStationService stationService, CancellationToken token)
        {
            var stations = await stationService.GetAllStationsAsync(tournamentId, token);
            return new ActionResult<List<Station>?>(stations);
        }

        [HttpPut("SetStation/{tournamentId}")]
        public async Task<ActionResult<List<Station>?>> UpdateCharacterAsync(int tournamentId, [FromBody] Station? station,
            [FromServices] IStationService stationService, CancellationToken token)
        {
            var stations = await stationService.SetStationForASetAsync(tournamentId, station, token);
            return new ActionResult<List<Station>?>(stations);
        }

        [HttpPut("RemoveStation/{tournamentId}/{setId}")]
        public async Task<ActionResult<List<Station>?>> UpdateCharacterAsync(int tournamentId, string setId,
            [FromServices] IStationService stationService, CancellationToken token)
        {
            var stations = await stationService.RemoveStationForASetAsync(tournamentId, setId, token);
            return new ActionResult<List<Station>?>(stations);
        }
    }
}
