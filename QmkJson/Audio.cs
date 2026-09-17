using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Audio
    {
        [JsonPropertyName("default")]
        public AudioDefault? Default { get; set; } = null;
        [JsonPropertyName("driver")]
        public AudioDriver? Driver { get; set; } = null;
        [JsonPropertyName("macro_beep")]
        public bool? MacroBeep { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("pins")]
        public IEnumerable<McuPin?>? Pins { get; set; } = null;
        [JsonPropertyName("power_control")]
        public AudioPowerControl? PowerControl { get; set; } = null;
        [JsonPropertyName("voices")]
        public bool? Voices { get; set; } = null;
    }

    public class AudioDefault
    {
        [JsonPropertyName("on")]
        public bool? On { get; set; } = null;
        [JsonPropertyName("clicky")]
        public bool? Clicky { get; set; } = null;
    }

    public enum AudioDriver
    {
        dac_additive,
        dac_basic,
        pwm_software,
        pwm_hardware,
    }

    public class AudioPowerControl
    {
        [JsonPropertyName("on_state")]
        public Bit? OnState { get; set; } = null;
        [JsonPropertyName("pin")]
        public McuPin? Pin { get; set; } = null;
    }
}
