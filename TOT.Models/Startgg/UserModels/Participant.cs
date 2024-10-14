namespace TOT.Models.Startgg.UserModels
{
    public class Participant
    {
        public int Id { get; set; }
        public string? GamerTag { get; set; }
        public string? Prefix { get; set; }
        public User? User { get; set; }
    }
}
