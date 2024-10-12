namespace TOT.DTO.Models.TournamentRelated
{
    public class BracketDto
    {
        public int Id { get; set; }
        public int StartggId { get; set; }
        public string? Name { get; set; }
        public List<SetDto> Sets { get; set; } = new();
    }
}
