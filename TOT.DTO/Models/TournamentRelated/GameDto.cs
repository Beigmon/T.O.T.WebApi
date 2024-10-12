namespace TOT.DTO.Models.TournamentRelated
{
    public class GameDto
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public int Number { get; set; }
        public List<CharacterSelectionDto> Selections { get; set; } = new();
    }
}
