using Microsoft.EntityFrameworkCore;
using TOT.DTO.Models.Player;

namespace TOT.DTO.Extensions
{
    public static class PlayerExtension
    {
        public static async Task<Player> GetByUserIdAsync(this DbSet<Player> players, int startggUserId,
            string? username, TotContext dbContext)
        {
            var player = players
                .Include(p => p.PlayerCharacters)
                .ThenInclude(p => p.Character)
                .FirstOrDefault(p => p.StartggUserId == startggUserId);

            if (player != null)
            {
                return player;
            }

            player = new Player
            {
                PlayerCharacters = [],
                StartggUserId = startggUserId,
                Username = username
            };

            var tracking = await dbContext.AddAsync(player);
            await dbContext.SaveChangesAsync();
            return tracking.Entity;
        }
    }
}
