using Microsoft.EntityFrameworkCore;
using TOT.DTO.Models.Discord;

namespace TOT.DTO.Extensions
{
    public static class DiscordServerExtension
    {
        public static DiscordServer? GetByGuildId(this DbSet<DiscordServer> discordServerSet, ulong guildId)
        {
            return discordServerSet
                .Include(discordServer => discordServer.BotConfiguration)
                .Include(ds => ds.BotConfiguration.AllowedSetChannelsRoles)
                .Include(ds => ds.Tournaments)
                .ThenInclude(ds => ds.Events)
                .FirstOrDefault(ds => ds.DiscordGuildId == guildId);
        }
    }
}
