namespace TOT.Models.Startgg
{
    public class UpdatePhaseSeedInfo
    {
        public int SeedId { get; set; }
        public int SeedNum { get; set; }
        public int PhaseGroupId { get; set; }
    }

    public class UpdatePhaseSeedInfoWithCustom : UpdatePhaseSeedInfo
    {
        public int UserId { get; set; }
        public string? GamerTag { get; set; }
    }
}
