using Microsoft.EntityFrameworkCore;
using TOT.DTO.Models.Player;

namespace TOT.DTO.Extensions
{
    public static class PlayerCharacterExtension
    {
        public static async Task<PlayerCharacter> GetByPlayerAndCharacter(this DbSet<PlayerCharacter> players, Player player,
            Character character, TotContext dbContext)
        {
            var playerCharacter = players
                .Include(p => p.Character)
                .Include(p => p.Player)
                .Where(p => p.Character.StartggId == character.StartggId)
                .FirstOrDefault(p => p.Player.StartggUserId == player.StartggUserId);

            if (playerCharacter != null)
            {
                return playerCharacter;
            }

            playerCharacter = new PlayerCharacter
            {
                Character = character,
                Player = player,
                Occurrence = 0
            };

            var tracking = await dbContext.AddAsync(playerCharacter);
            await dbContext.SaveChangesAsync();
            return tracking.Entity;
        }
    }
}
