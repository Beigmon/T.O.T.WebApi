using Microsoft.EntityFrameworkCore;
using TOT.DTO.Models.Discord;

namespace TOT.DTO.Extensions
{
    public static class DiscordRoleExtension
    {
        public static List<DiscordRole> GetRolesByDiscordServerId(this DbSet<DiscordRole> roles,
            ulong discordGuild)
        {
            return roles
                .Include(r => r.BotConfiguration)
                .Include(r => r.BotConfiguration.DiscordServer)
                .Where(r => r.BotConfiguration.DiscordServer.DiscordGuildId == discordGuild)
                .ToList();
        }
    }
}
