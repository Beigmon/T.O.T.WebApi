using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TOT.DTO.Models.Player;
using TOT.Services.ControllerServices.Interfaces;

namespace TOT.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [EnableRateLimiting("fixed")]
    public class PlayerController(ILogger<PlayerController> logger)
        : ControllerBase
    {
        [HttpGet("Characters/{userStartggId}:{userGamerTag}")]
        public async Task<ActionResult<Player>> GetPlayerAsync(int userStartggId, string userGamerTag, [FromServices] IPlayerService playerService)
        {
            var player = await playerService.GetPlayerCharacters(userStartggId, userGamerTag);
            return new ActionResult<Player>(player);
        }

        [HttpPut("Characters/{userStartggId}:{userGamerTag}")]
        public async Task<ActionResult<Player>> UpdateCharacterAsync(int userStartggId, string userGamerTag, [FromBody] List<Character> character,
            [FromServices] IPlayerService playerService)
        {
            var player = await playerService.IncreaseOccurrencesAsync(userStartggId, userGamerTag, character);
            return new ActionResult<Player>(player);
        }
    }
}
