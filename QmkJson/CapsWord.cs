using System.Text.Json.Serialization;

namespace QmkJson
{
    public class CapsWord
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("both_shifts_turns_on")]
        public bool? BothShiftsTurnsOn { get; set; } = null;
        [JsonPropertyName("double_tap_shift_turns_on")]
        public bool? DoubleTapShiftTurnsOn { get; set; } = null;
        [JsonPropertyName("idle_timeout")]
        public uint? IdleTimeout { get; set; } = null;
        [JsonPropertyName("invert_on_shift")]
        public bool? InvertOnShift { get; set; } = null;
    }
}
