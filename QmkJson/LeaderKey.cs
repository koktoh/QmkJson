using System.Text.Json.Serialization;

namespace QmkJson
{
    public class LeaderKey
    {
        [JsonPropertyName("timing")]
        public bool? Timing { get; set; } = null;
        [JsonPropertyName("strict_processing")]
        public bool? StrictProcessing { get; set; } = null;
        [JsonPropertyName("timeout")]
        public uint? Timeout { get; set; } = null;
    }
}
