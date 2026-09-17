using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Stenography
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("combined_map")]
        public bool? CombinedMap { get; set; } = null;
        [JsonPropertyName("default")]
        public StenographyDefault? Default { get; set; } = null;
        [JsonPropertyName("protocol")]
        public StenographyProtocol? Protocol { get; set; } = null;
    }

    public enum StenographyMode
    {
        geminipr,
        txbolt,
    }

    public class StenographyDefault
    {
        [JsonPropertyName("mode")]
        public StenographyMode? Mode { get; set; } = null;
    }

    public enum StenographyProtocol
    {
        all,
        geminipr,
        txbolt,
    }
}
