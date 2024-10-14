using TOT.Models.Startgg.Connections;
using TOT.Models.Startgg.Responses;
using TOT.Models.Startgg.Scheduling;

namespace TOT.Models.Startgg.TournamentHierarchy
{
    public class PhaseGroup
    {
        public int Id { get; set; }

        public int State { get; set; }

        public string? DisplayIdentifier { get; set; }

        public Phase? Phase { get; set; }
        public Wave? Wave { get; set; }
        public SetConnection? Sets { get; set; }
    }
}
