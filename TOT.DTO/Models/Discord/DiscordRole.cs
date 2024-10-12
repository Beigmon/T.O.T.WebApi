using System.ComponentModel.DataAnnotations;
using TOT.DTO.Models.Configuration;

namespace TOT.DTO.Models.Discord
{
    public class DiscordRole
    {
        [Key]
        public int Id { get; set; }
        public ulong DiscordId { get; set; }
        public BotConfiguration BotConfiguration { get; set; } = default!;

        public int BotConfigurationId { get; set; }
    }
}
