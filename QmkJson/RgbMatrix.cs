using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class RgbMatrix
    {
        [JsonPropertyName("animations")]
        public RgbMatrixAnimations? Animations { get; set; } = null;
        [JsonPropertyName("default")]
        public RgbMatrixDefault? Default { get; set; } = null;
        [JsonPropertyName("driver")]
        public RgbMatrixDriver? Driver { get; set; } = null;
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
        [JsonPropertyName("hue_steps")]
        public uint? HueSteps { get; set; } = null;
        [JsonPropertyName("sat_steps")]
        public uint? SatSteps { get; set; } = null;
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
        public IEnumerable<RgbLed>? Layout { get; set; } = null;
    }

    public class RgbMatrixAnimations
    {
        [JsonPropertyName("none")]
        public bool? None { get; set; } = null;
        [JsonPropertyName("solid_color")]
        public bool? SolidColor { get; set; } = null;
        [JsonPropertyName("alphas_mods")]
        public bool? AlphasMods { get; set; } = null;
        [JsonPropertyName("gradient_up_down")]
        public bool? GradientUpDown { get; set; } = null;
        [JsonPropertyName("gradient_left_right")]
        public bool? GradientLeftRight { get; set; } = null;
        [JsonPropertyName("breathing")]
        public bool? Breathing { get; set; } = null;
        [JsonPropertyName("band_sat")]
        public bool? BandSat { get; set; } = null;
        [JsonPropertyName("band_val")]
        public bool? BandVal { get; set; } = null;
        [JsonPropertyName("band_pinwheel_sat")]
        public bool? BandPinwheelSat { get; set; } = null;
        [JsonPropertyName("band_pinwheel_val")]
        public bool? BandPinwheelVal { get; set; } = null;
        [JsonPropertyName("band_spiral_sat")]
        public bool? BandSpiralSat { get; set; } = null;
        [JsonPropertyName("band_spiral_val")]
        public bool? BandSpiralVal { get; set; } = null;
        [JsonPropertyName("cycle_all")]
        public bool? CycleAll { get; set; } = null;
        [JsonPropertyName("cycle_left_right")]
        public bool? CycleLeftRight { get; set; } = null;
        [JsonPropertyName("cycle_up_down")]
        public bool? CycleUpDown { get; set; } = null;
        [JsonPropertyName("cycle_out_in")]
        public bool? CycleOutIn { get; set; } = null;
        [JsonPropertyName("cycle_out_in_dual")]
        public bool? CycleOutInDual { get; set; } = null;
        [JsonPropertyName("rainbow_moving_chevron")]
        public bool? RainbowMovingChevron { get; set; } = null;
        [JsonPropertyName("cycle_pinwheel")]
        public bool? CyclePinwheel { get; set; } = null;
        [JsonPropertyName("cycle_spiral")]
        public bool? CycleSpiral { get; set; } = null;
        [JsonPropertyName("dual_beacon")]
        public bool? DualBeacon { get; set; } = null;
        [JsonPropertyName("rainbow_beacon")]
        public bool? RainbowBeacon { get; set; } = null;
        [JsonPropertyName("rainbow_pinwheels")]
        public bool? RainbowPinwheels { get; set; } = null;
        [JsonPropertyName("flower_blooming")]
        public bool? FlowerBlooming { get; set; } = null;
        [JsonPropertyName("raindrops")]
        public bool? Raindrops { get; set; } = null;
        [JsonPropertyName("jellybean_raindrops")]
        public bool? JellybeanRaindrops { get; set; } = null;
        [JsonPropertyName("hue_breathing")]
        public bool? HueBreathing { get; set; } = null;
        [JsonPropertyName("hue_pendulum")]
        public bool? HuePendulum { get; set; } = null;
        [JsonPropertyName("hue_wave")]
        public bool? HueWave { get; set; } = null;
        [JsonPropertyName("pixel_fractal")]
        public bool? PixelFractal { get; set; } = null;
        [JsonPropertyName("pixel_flow")]
        public bool? PixelFlow { get; set; } = null;
        [JsonPropertyName("pixel_rain")]
        public bool? PixelRain { get; set; } = null;
        [JsonPropertyName("typing_heatmap")]
        public bool? TypingHeatmap { get; set; } = null;
        [JsonPropertyName("digital_rain")]
        public bool? DigitalRain { get; set; } = null;
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
        [JsonPropertyName("solid_splash")]
        public bool? SolidSplash { get; set; } = null;
        [JsonPropertyName("solid_multisplash")]
        public bool? SolidMultisplash { get; set; } = null;
        [JsonPropertyName("starlight")]
        public bool? Starlight { get; set; } = null;
        [JsonPropertyName("starlight_smooth")]
        public bool? StarlightSmooth { get; set; } = null;
        [JsonPropertyName("starlight_dual_hue")]
        public bool? StarlightDualHue { get; set; } = null;
        [JsonPropertyName("starlight_dual_sat")]
        public bool? StarlightDualSat { get; set; } = null;
        [JsonPropertyName("riverflow")]
        public bool? Riverflow { get; set; } = null;
    }

    public class RgbMatrixDefault
    {
        [JsonPropertyName("on")]
        public bool? On { get; set; } = null;
        [JsonPropertyName("animation")]
        public string? Animation { get; set; } = null;
        [JsonPropertyName("hue")]
        public byte? Hue { get; set; } = null;
        [JsonPropertyName("sat")]
        public byte? Sat { get; set; } = null;
        [JsonPropertyName("val")]
        public byte? Val { get; set; } = null;
        [JsonPropertyName("speed")]
        public byte? Speed { get; set; } = null;
        [JsonPropertyName("flags")]
        public byte? Flags { get; set; } = null;
    }

    public enum RgbMatrixDriver
    {
        aw20216s,
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
        ws2812,
    }

    [JsonCompact]
    public class RgbLed
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
