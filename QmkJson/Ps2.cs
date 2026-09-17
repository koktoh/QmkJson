using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Ps2
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("mouse_enabled")]
        public bool? MouseEnabled { get; set; } = null;
        [JsonPropertyName("clock_pin")]
        public McuPin? ClockPin { get; set; } = null;
        [JsonPropertyName("data_pin")]
        public McuPin? DataPin { get; set; } = null;
        [JsonPropertyName("driver")]
        public Ps2Driver? Driver { get; set; } = null;
    }

    public enum Ps2Driver
    {
        busywait,
        interrupt,
        usart,
        vendor,
    }
}
