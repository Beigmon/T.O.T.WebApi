using System.ComponentModel.DataAnnotations;

namespace TOT.DTO.Models.Player
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int StartggId { get; set; }
        public string? Name { get; set; }
        public List<Character> Characters { get; set; } = new();
    }
}
