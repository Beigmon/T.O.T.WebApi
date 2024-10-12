namespace TOT.DTO.Models.TournamentRelated
{
    public class EventDto
    {
        public int Id { get; set; }
        public int StartggId { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }

        public TournamentDto Tournament { get; set; } = default!;

        public int TournamentId { get; set; }
    }
}
