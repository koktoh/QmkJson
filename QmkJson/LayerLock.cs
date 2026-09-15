using System.Text.Json.Serialization;

namespace QmkJson
{
    public class LayerLock
    {
        [JsonPropertyName("timeout")]
        public uint? Timeout { get; set; } = null;
    }
}
