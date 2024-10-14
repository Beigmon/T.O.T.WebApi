using TOT.DTO;
using TOT.DTO.Extensions;
using TOT.DTO.Models.Player;
using TOT.Models.Startgg.UserModels;
using TOT.Services.ControllerServices.Interfaces;

namespace TOT.Services.ControllerServices
{
    public class PlayerService(TotContext dbContext) : IPlayerService
    {
        public async Task<Player> GetPlayerCharacters(int startggUserId, string gamerTag)
        {
            if (startggUserId == 0)
            {
                throw new ArgumentException("Player user id was not found");
            }

            var dbPlayer = await dbContext.Players.GetByUserIdAsync(startggUserId, gamerTag, dbContext);
            return dbPlayer;
        }

        /// <summary>
        /// Increase the occurrence of the played characters for the player in the database
        /// </summary>
        public async Task<Player> IncreaseOccurrencesAsync(int userStartggId, string gamerTag, IEnumerable<Character?> playedCharacters)
        {
            var dbPlayer = await dbContext.Players.GetByUserIdAsync(userStartggId, gamerTag, dbContext);
            foreach (var character in playedCharacters)
            {
                if (character == null)
                    continue;

                var playerCharacter = await dbContext.PlayerCharacters.GetByPlayerAndCharacter(dbPlayer, character, dbContext);

                playerCharacter.Occurrence++;
                await dbContext.SaveChangesAsync();
            }

            return dbPlayer;
        }
    }
}
