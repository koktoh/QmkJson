using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Bootmagic
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("matrix")]
        public Matrix? Matrix { get; set; } = null;
    }
}
