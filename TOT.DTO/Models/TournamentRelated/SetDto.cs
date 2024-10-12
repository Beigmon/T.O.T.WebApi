using System.ComponentModel.DataAnnotations;

namespace TOT.DTO.Models.TournamentRelated
{
    public class SetDto
    {
        [Key]
        public int Id { get; set; }
        public string? StartggId { get; set; }
        public int WinnerId { get; set; }
        public List<GameDto> Games { get; set; } = new();
    }
}
