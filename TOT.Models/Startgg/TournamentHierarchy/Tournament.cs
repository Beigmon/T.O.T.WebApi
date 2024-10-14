using TOT.Models.Startgg.Connections;
using TOT.Models.Startgg.Responses;

namespace TOT.Models.Startgg.TournamentHierarchy
{
    public class Tournament
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public string? Slug { get; set; }
        public string? Url { get; set; }

        public StationsConnection? Stations { get; set; }
        public List<StreamQueue>? StreamQueue { get; set; }
        public List<Event> Events { get; set; } = new();
    }
}
