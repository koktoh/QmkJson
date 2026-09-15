using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Tapping
    {
        [JsonPropertyName("chordal_hold")]
        public bool? ChordalHold { get; set; } = null;
        [JsonPropertyName("flow_tap_term")]
        public uint? FlowTapTerm { get; set; } = null;
        [JsonPropertyName("force_hold")]
        public bool? ForceHold { get; set; } = null;
        [JsonPropertyName("force_hold_per_key")]
        public bool? ForceHoldPerKey { get; set; } = null;
        [JsonPropertyName("ignore_mod_tap_interrupt")]
        public bool? IgnoreModTapInterrupt { get; set; } = null;
        [JsonPropertyName("hold_on_other_key_press")]
        public bool? HoldOnOtherKeyPress { get; set; } = null;
        [JsonPropertyName("hold_on_other_key_press_per_key")]
        public bool? HoldOnOtherKeyPressPerKey { get; set; } = null;
        [JsonPropertyName("permissive_hold")]
        public bool? PermissiveHold { get; set; } = null;
        [JsonPropertyName("permissive_hold_per_key")]
        public bool? PermissiveHoldPerKey { get; set; } = null;
        [JsonPropertyName("retro")]
        public bool? Retro { get; set; } = null;
        [JsonPropertyName("retro_per_key")]
        public bool? RetroPerKey { get; set; } = null;
        [JsonPropertyName("speculative_hold")]
        public bool? SpeculativeHold { get; set; } = null;
        [JsonPropertyName("speculative_hold_flow_term")]
        public uint? SpeculativeHoldFlowTerm { get; set; } = null;
        [JsonPropertyName("speculative_hold_one_key")]
        public bool? SpeculativeHoldOneKey { get; set; } = null;
        [JsonPropertyName("term")]
        public uint? Term { get; set; } = null;
        [JsonPropertyName("term_per_key")]
        public bool? TermPerKey { get; set; } = null;
        [JsonPropertyName("toggle")]
        public uint? Toggle { get; set; } = null;
    }
}
