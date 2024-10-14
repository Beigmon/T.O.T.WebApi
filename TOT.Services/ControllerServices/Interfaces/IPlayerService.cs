using TOT.DTO.Models.Player;

namespace TOT.Services.ControllerServices.Interfaces
{
    public interface IPlayerService
    {
        public Task<Player> GetPlayerCharacters(int startggUserId, string gamerTag);

        public Task<Player> IncreaseOccurrencesAsync(int userStartggId, string gamerTag, IEnumerable<Character?> playedCharacters);
    }
}
