namespace TOT.Models.Startgg
{
    public class TournamentType
    {
        public Tournaments? Tournaments { get; set; }
    }

    public class Tournaments
    {
        public List<Node>? Nodes { get; set; }
    }

    public class Node
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
        public string? Slug { get; set; }
    }
}
