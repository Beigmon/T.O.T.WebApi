using System.ComponentModel.DataAnnotations;

namespace TOT.DTO.Models.Player
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public int StartggId { get; set; }
        public string? Name { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; } = new();
    }
}
