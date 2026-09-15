using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Backlight
    {
        [JsonPropertyName("driver")]
        public BacklightDriver? Driver { get; set; } = null;
        [JsonPropertyName("default")]
        public BacklightDefault? Default { get; set; } = null;
        [JsonPropertyName("breathing")]
        public bool? Breathing { get; set; } = null;
        [JsonPropertyName("breathing_period")]
        public byte? BreathingPeriod { get; set; } = null;
        [JsonPropertyName("levels")]
        public byte? Levels { get; set; } = null;
        [JsonPropertyName("max_brightness")]
        public byte? MaxBrightness { get; set; } = null;
        [JsonPropertyName("pin")]
        public McuPin? Pin { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("pins")]
        public IEnumerable<McuPin?>? Pins { get; set; } = null;
        [JsonPropertyName("on_state")]
        public Bit? OnState { get; set; } = null;
        [JsonPropertyName("as_caps_lock")]
        public bool? AsCapsLock { get; set; } = null;
    }

    public enum BacklightDriver
    {
        custom,
        pwm,
        software,
        timer,
    }

    public class BacklightDefault
    {
        [JsonPropertyName("on")]
        public bool? On { get; set; } = null;
        [JsonPropertyName("breathing")]
        public bool? Breathing { get; set; } = null;
        [JsonPropertyName("brightness")]
        public byte? Brightness { get; set; } = null;
    }
}
