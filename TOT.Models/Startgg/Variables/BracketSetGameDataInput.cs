namespace TOT.Models.Startgg.Variables
{
    public class BracketSetGameDataInput
    {
        public int WinnerId { get; set; }
        public int GameNum { get; set; }
        public int Entrant1Score { get; set; }
        public int Entrant2Score { get; set; }
        public List<BracketSetGameSelectionInput>? Selections { get; set; }
    }
}
