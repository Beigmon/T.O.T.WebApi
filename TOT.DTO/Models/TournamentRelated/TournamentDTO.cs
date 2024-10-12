using System.ComponentModel.DataAnnotations;
using TOT.DTO.Models.Discord;

namespace TOT.DTO.Models.TournamentRelated
{
    public class TournamentDto
    {
        [Key]
        public int Id { get; set; }
        public string? Slug { get; set; }
        public int StartggId { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }

        public DiscordServer DiscordServer { get; set; } = default!;
        public List<EventDto> Events { get; set; } = new();

        public int DiscordServerId { get; set; }
    }
}
