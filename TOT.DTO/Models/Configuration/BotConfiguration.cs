using System.ComponentModel.DataAnnotations;
using TOT.DTO.Models.Discord;

namespace TOT.DTO.Models.Configuration
{
    public class BotConfiguration
    {
        [Key]
        public int Id { get; set; }
        public string? StartggToken { get; set; }
        public DiscordServer DiscordServer { get; set; } = default!;
        public List<DiscordRole> AllowedSetChannelsRoles { get; set; } = new();

        public int DiscordServerId { get; set; }
    }
}
