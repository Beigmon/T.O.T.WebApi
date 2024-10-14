using TOT.Models.Startgg.TournamentHierarchy;

namespace TOT.Models.Startgg.SetModels
{
    public class GgqlSet
    {
        public string? Id { get; set; }
        public List<SetSlot?>? Slots { get; set; }
        public string? FullRoundText { get; set; }
        public List<Game>? Games { get; set; }
        public PhaseGroup? PhaseGroup { get; set; }
        public Event? Event { get; set; }
        public GqlStream? Stream { get; set; }
        public int State { get; set; }
        public int? CompletedAt { get; set; }

        public ulong ToStartCategoryId { get; set; }
        public ulong StartedCategoryId { get; set; }
    }
}