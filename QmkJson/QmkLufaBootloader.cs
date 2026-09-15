using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class QmkLufaBootloader
    {
        [JsonPropertyName("esc_output")]
        public McuPin? EscOutput { get; set; } = null;
        [JsonPropertyName("esc_input")]
        public McuPin? EscInput { get; set; } = null;
        [JsonPropertyName("led")]
        public McuPin? Led { get; set; } = null;
        [JsonPropertyName("speaker")]
        public McuPin? Speaker { get; set; } = null;
    }
}
