using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Secure
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("unlock_timeout")]
        public uint? UnlockTimeout { get; set; } = null;
        [JsonPropertyName("idle_timeout")]
        public uint? IdleTimeout { get; set; } = null;
        [JsonPropertyName("unlock_sequence")]
        public IEnumerable<Matrix>? UnlockSequence { get; set; } = null;
    }
}
