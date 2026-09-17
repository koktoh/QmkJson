using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Apa102
    {
        [JsonPropertyName("data_pin")]
        public McuPin? DataPin { get; set; } = null;
        [JsonPropertyName("clock_pin")]
        public McuPin? ClockPin { get; set; } = null;
        [JsonPropertyName("default_brightness")]
        public int? DefaultBrightness { get; set; } = null;
    }
}
