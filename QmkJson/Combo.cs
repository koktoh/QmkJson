using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Combo
    {
        [JsonPropertyName("count")]
        public uint? Count { get; set; } = null;
        [JsonPropertyName("term")]
        public uint? Term { get; set; } = null;
    }
}
