using Microsoft.EntityFrameworkCore;
using TOT.DTO.Models.Player;

namespace TOT.DTO.Extensions
{
    public static class CharacterExtension
    {
        public static async Task<Character> GetByStartggId(this DbSet<Character> characters, int startggId,
            string name, TotContext dbContext)
        {
            var character = characters
                .Include(p => p.PlayerCharacters)
                .FirstOrDefault(p => p.StartggId == startggId);

            if (character != null)
            {
                return character;
            }

            character = new Character
            {
                StartggId = startggId,
                Name = name,
                PlayerCharacters = []
            };

            var tracking = await dbContext.AddAsync(character);
            await dbContext.SaveChangesAsync();
            return tracking.Entity;
        }
    }
}
