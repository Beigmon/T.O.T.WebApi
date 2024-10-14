using TOT.Models.Startgg.UserModels;

namespace TOT.Models.Startgg.SetModels
{
    public class GameSelection
    {
        public int Id { get; set; }
        public string? SelectionType { get; set; }
        public int SelectionValue { get; set; }
        public Participant? Participant { get; set; }
        public Entrant? Entrant { get; set; }
        public Character? Character { get; set; }
    }
}
