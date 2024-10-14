using TOT.Models.Startgg.Connections;
using TOT.Models.Startgg.Responses;
using TOT.Models.Startgg.Scheduling;

namespace TOT.Models.Startgg.TournamentHierarchy
{
    public class Event
    {
        public int Id { get; set; }
        public ActivityState State { get; set; }

        public string? Slug { get; set; }
        public string? Name { get; set; }

        public int StartAt { get; set; }
        public int NumEntrants { get; set; }

        public EntrantConnection? Entrants { get; set; }
        public StandingConnection? Standings { get; set; }
        public Tournament? Tournament { get; set; }
        public SetConnection? Sets { get; set; }

        public List<PhaseGroup>? PhaseGroups { get; set; }
        public List<Phase>? Phases { get; set; }
        public List<Wave>? Waves { get; set; }
    }
}
