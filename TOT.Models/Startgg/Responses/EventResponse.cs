using TOT.Models.Startgg.Connections;
using TOT.Models.Startgg.TournamentHierarchy;
using TOT.Models.Startgg.UserModels;

namespace TOT.Models.Startgg.Responses
{
    public class EventResponse
    {
        public Event? Event { get; set; }

        public bool HasSets()
        {
            return Event?.PhaseGroups != null
                   && Event.PhaseGroups.Any(pg => pg.Phase?.Sets?.Nodes?.Count != 0);
        }
    }

    public class EntrantConnection
    {
        public List<Entrant>? Nodes { get; set; }
    }

    public class Phase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ActivityState State { get; set; }
        public SeedConnection? Seeds { get; set; }
        public SetConnection? Sets { get; set; }
        public PhaseGroupConnection? PhaseGroups { get; set; }
    }

    public class SeedConnection
    {
        public List<Seed>? Nodes { get; set; }
    }

    public class Seed
    {
        public int Id { get; set; }
        public int SeedNum { get; set; }
        public Entrant? Entrant { get; set; }
    }

    public class StandingConnection
    {
        public List<Standing>? Nodes { get; set; }
    }

    public class Standing
    {
        public int Placement { get; set; }
        public Player? Player { get; set; }
        public Entrant? Entrant { get; set; }
    }

    public class PlayerType
    {
        public Player? Player { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string? GamerTag { get; set; }
        public string? Prefix { get; set; }
        public User? User { get; set; }
        public SetConnection? Sets { get; set; }
    }

    public enum ActivityState
    {
        CREATED,
        ACTIVE,
        COMPLETED,
        READY,
        INVALID,
        CALLED,
        QUEUED
    }
}
