using TOT.Models.Startgg.SetModels;
using TOT.Models.Startgg.TournamentHierarchy;

namespace TOT.Models.Startgg.Responses
{
    public class StreamQueueType
    {
        public Tournament? Tournament { get; set; }
    }

    public class StreamQueue
    {
        public Stream? Stream { get; set; }
        public List<GgqlSet?>? Sets { get; set; }
    }

    public class Stream
    {
        public string? StreamSource { get; set; }
        public string? StreamName { get; set; }
    }
}
