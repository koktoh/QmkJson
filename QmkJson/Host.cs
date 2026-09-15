using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Host
    {
        [JsonPropertyName("default")]
        public HostDefault? Default { get; set; } = null;
    }

    public class HostDefault
    {
        [JsonPropertyName("nkro")]
        public bool? Nkro { get; set; } = null;
    }
}
