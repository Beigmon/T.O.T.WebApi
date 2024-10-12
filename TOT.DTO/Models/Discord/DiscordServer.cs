using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TOT.DTO.Models.Configuration;
using TOT.DTO.Models.TournamentRelated;

namespace TOT.DTO.Models.Discord
{
    public class DiscordServer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ulong DiscordGuildId { get; set; }
        public DateTime JoinedAt { get; set; }

        public string? ReferenceUser { get; set; }
        public string? DiscordName { get; set; }
        public bool RunningTournament { get; set; }

        public BotConfiguration BotConfiguration { get; set; } = default!;
        public DiscordConfiguration? DiscordConfiguration { get; set; } = default!;
        public List<TournamentDto> Tournaments { get; set; } = new();
    }
}
