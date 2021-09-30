using System;

namespace Tuna_Session_Builder.Domain
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
        public string TimeSignature { get; set; }
        public DateTime DurationEstimate { get; set; }
    }
}
