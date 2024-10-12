using System.ComponentModel.DataAnnotations;

namespace TOT.DTO.Models.Player
{
    public class PlayerCharacter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Character Character { get; set; } = null!;

        [Required]
        public Player Player { get; set; } = null!;

        public int Occurrence { get; set; }

        public int PlayerId { get; set; }
        public int CharacterId { get; set; }
    }
}
