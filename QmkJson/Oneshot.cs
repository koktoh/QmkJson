using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Oneshot
    {
        [JsonPropertyName("tap_toggle")]
        public uint? TapToggle { get; set; } = null;
        [JsonPropertyName("timeout")]
        public uint? Timeout { get; set; } = null;
    }
}
