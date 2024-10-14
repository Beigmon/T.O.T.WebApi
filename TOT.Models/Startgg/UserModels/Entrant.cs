using TOT.Models.Startgg.Responses;

namespace TOT.Models.Startgg.UserModels
{
    public class Entrant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Participant>? Participants { get; set; }
        public Standing? Standing { get; set; }

        public int GetParticipant1UserId()
        {
            var participant = Participants?[0];
            return GetUserId(participant);
        }

        public int GetParticipant2UserId()
        {
            var participant = Participants?[1];
            return GetUserId(participant);
        }

        public string? GetParticipant1GamerTag()
        {
            var participant = Participants?[0];
            return GetGamerTag(participant);
        }

        public string? GetParticipant2GamerTag()
        {
            var participant = Participants?[1];
            return GetGamerTag(participant);
        }

        private static int GetUserId(Participant? participant)
        {
            return participant?.User?.Id ?? 0;
        }

        private static string? GetGamerTag(Participant? participant)
        {
            return participant?.GamerTag;
        }
    }
}
