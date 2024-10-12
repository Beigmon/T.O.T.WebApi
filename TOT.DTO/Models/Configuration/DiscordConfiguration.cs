using System.ComponentModel.DataAnnotations;
using TOT.DTO.Models.Discord;

namespace TOT.DTO.Models.Configuration
{
    public class DiscordConfiguration
    {
        [Key]
        public int Id { get; set; }
        public string? CustomPrefix { get; set; }
        public DiscordServer DiscordServer { get; set; } = default!;

        public int DiscordServerId { get; set; }
    }
}
