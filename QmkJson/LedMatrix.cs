using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class LedMatrix
    {
        [JsonPropertyName("animations")]
        public LedMatrixAnimations? Animations { get; set; } = null;
        [JsonPropertyName("default")]
        public LedMatrixDefault? Default { get; set; } = null;
        [JsonPropertyName("driver")]
        public LedMatrixDriver? Driver { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("center_point")]
        public Matrix? CenterPoint { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("flag_steps")]
        public IEnumerable<byte>? FlagSteps { get; set; } = null;
        [JsonPropertyName("max_brightness")]
        public byte? MaxBrightness { get; set; } = null;
        [JsonPropertyName("timeout")]
        public uint? Timeout { get; set; } = null;
        [JsonPropertyName("val_steps")]
        public uint? ValSteps { get; set; } = null;
        [JsonPropertyName("speed_steps")]
        public uint? SpeedSteps { get; set; } = null;
        [JsonPropertyName("led_flush_limit")]
        public uint? LedFlushLimit { get; set; } = null;
        [JsonPropertyName("led_process_limit")]
        public uint? LedProcessLimit { get; set; } = null;
        [JsonPropertyName("react_on_keyup")]
        public bool? ReactOnKeyup { get; set; } = null;
        [JsonPropertyName("sleep")]
        public bool? Sleep { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("split_count")]
        public SplitCount? SplitCount { get; set; } = null;
        [JsonPropertyName("layout")]
        public IEnumerable<Led>? Layout { get; set; } = null;
    }

    public class LedMatrixAnimations
    {
        [JsonPropertyName("none")]
        public bool? None { get; set; } = null;
        [JsonPropertyName("solid")]
        public bool? Solid { get; set; } = null;
        [JsonPropertyName("alphas_mods")]
        public bool? AlphasMods { get; set; } = null;
        [JsonPropertyName("breathing")]
        public bool? Breathing { get; set; } = null;
        [JsonPropertyName("band")]
        public bool? Band { get; set; } = null;
        [JsonPropertyName("band_pinwheel")]
        public bool? BandPinwheel { get; set; } = null;
        [JsonPropertyName("band_spiral")]
        public bool? BandSpiral { get; set; } = null;
        [JsonPropertyName("cycle_left_right")]
        public bool? CycleLeftRight { get; set; } = null;
        [JsonPropertyName("cycle_up_down")]
        public bool? CycleUpDown { get; set; } = null;
        [JsonPropertyName("cycle_out_in")]
        public bool? CycleOutIn { get; set; } = null;
        [JsonPropertyName("dual_beacon")]
        public bool? DualBeacon { get; set; } = null;
        [JsonPropertyName("solid_reactive_simple")]
        public bool? SolidReactiveSimple { get; set; } = null;
        [JsonPropertyName("solid_reactive")]
        public bool? SolidReactive { get; set; } = null;
        [JsonPropertyName("solid_reactive_wide")]
        public bool? SolidReactiveWide { get; set; } = null;
        [JsonPropertyName("solid_reactive_multiwide")]
        public bool? SolidReactiveMultiwide { get; set; } = null;
        [JsonPropertyName("solid_reactive_cross")]
        public bool? SolidReactiveCross { get; set; } = null;
        [JsonPropertyName("solid_reactive_multicross")]
        public bool? SolidReactiveMulticross { get; set; } = null;
        [JsonPropertyName("solid_reactive_nexus")]
        public bool? SolidReactiveNexus { get; set; } = null;
        [JsonPropertyName("solid_reactive_multinexus")]
        public bool? SolidReactiveMultinexus { get; set; } = null;
        [JsonPropertyName("splash")]
        public bool? Splash { get; set; } = null;
        [JsonPropertyName("multisplash")]
        public bool? Multisplash { get; set; } = null;
        [JsonPropertyName("wave_left_right")]
        public bool? WaveLeftRight { get; set; } = null;
        [JsonPropertyName("wave_up_down")]
        public bool? WaveUpDown { get; set; } = null;
        [JsonPropertyName("typing_heatmap")]
        public bool? TypingHeatmap { get; set; } = null;
    }

    public class LedMatrixDefault
    {
        [JsonPropertyName("on")]
        public bool? On { get; set; } = null;
        [JsonPropertyName("animation")]
        public string? Animation { get; set; } = null;
        [JsonPropertyName("val")]
        public byte? Val { get; set; } = null;
        [JsonPropertyName("speed")]
        public byte? Speed { get; set; } = null;
        [JsonPropertyName("flags")]
        public byte? Flags { get; set; } = null;
    }

    public enum LedMatrixDriver
    {
        custom,
        is31fl3218,
        is31fl3236,
        is31fl3729,
        is31fl3731,
        is31fl3733,
        is31fl3736,
        is31fl3737,
        is31fl3741,
        is31fl3742a,
        is31fl3743a,
        is31fl3745,
        is31fl3746a,
        snled27351,
    }

    [JsonCompact]
    public class Led
    {
        [JsonPropertyName("matrix")]
        public Matrix? Matrix { get; set; } = null;
        [JsonPropertyName("x")]
        public required uint X { get; set; } = 0;
        [JsonPropertyName("y")]
        public required uint Y { get; set; } = 0;
        [JsonPropertyName("flags")]
        public byte? Flags { get; set; } = null;
    }
}
