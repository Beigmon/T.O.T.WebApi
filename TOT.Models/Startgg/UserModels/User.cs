using TOT.Models.Startgg.Connections;

namespace TOT.Models.Startgg.UserModels
{
    public class User
    {
        public int Id { get; set; }
        public string? GenderPronoun { get; set; }
        public List<LinkedNetwork>? Authorizations { get; set; }
        public TournamentConnection? Tournaments { get; set; }

        public string? GetTwitter()
        {
            var twitter = Authorizations?.FirstOrDefault(auth => auth.Type == "TWITTER");

            return twitter?.ExternalUsername;
        }
    }
}
