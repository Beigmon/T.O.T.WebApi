using System.ComponentModel.DataAnnotations;

namespace TOT.DTO.Models.Player
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public int StartggUserId { get; set; }
        public string? Username { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; } = new();
    }
}
