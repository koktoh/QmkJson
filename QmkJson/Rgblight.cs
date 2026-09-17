using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Rgblight
    {
        [JsonPropertyName("animations")]
        public RgblightAnimations? Animations { get; set; } = null;
        [JsonPropertyName("brightness_steps")]
        public uint? BrightnessSteps { get; set; } = null;
        [JsonPropertyName("default")]
        public RgblightDefault? Default { get; set; } = null;
        [JsonPropertyName("driver")]
        public RgblightDriver? Driver { get; set; } = null;
        [JsonPropertyName("hue_steps")]
        public uint? HueSteps { get; set; } = null;
        [JsonPropertyName("layers")]
        public RgblightLayers? Layers { get; set; } = null;
        [JsonPropertyName("led_count")]
        public uint? LedCount { get; set; } = null;
        [JsonPropertyName("led_map")]
        public IEnumerable<uint>? LedMap { get; set; } = null;
        [JsonPropertyName("max_brightness")]
        public byte? MaxBrightness { get; set; } = null;
        [Obsolete($"Use {nameof(WS2812)}.{nameof(WS2812.Pin)} instead.")]
        [JsonPropertyName("pin")]
        public McuPin? Pin { get; set; } = null;
        [Obsolete($"Use {nameof(WS2812)}.{nameof(WS2812.Rgbw)} instead.")]
        [JsonPropertyName("rgbw")]
        public bool? Rgbw { get; set; } = null;
        [JsonPropertyName("saturation_steps")]
        public uint? SaturationSteps { get; set; } = null;
        [JsonPropertyName("sleep")]
        public bool? Sleep { get; set; } = null;
        [JsonPropertyName("split")]
        public bool? Split { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("split_count")]
        public SplitCount? SplitCount { get; set; } = null;
    }

    public class RgblightAnimations
    {
        [JsonPropertyName("static_light")]
        public bool? StaticLight { get; set; } = null;
        [JsonPropertyName("breathing")]
        public bool? Breathing { get; set; } = null;
        [JsonPropertyName("rainbow_mood")]
        public bool? RainbowMood { get; set; } = null;
        [JsonPropertyName("rainbow_swirl")]
        public bool? RainbowSwirl { get; set; } = null;
        [JsonPropertyName("snake")]
        public bool? Snake { get; set; } = null;
        [JsonPropertyName("knight")]
        public bool? Knight { get; set; } = null;
        [JsonPropertyName("christmas")]
        public bool? Christmas { get; set; } = null;
        [JsonPropertyName("static_gradient")]
        public bool? StaticGradient { get; set; } = null;
        [JsonPropertyName("rgb_test")]
        public bool? RgbTest { get; set; } = null;
        [JsonPropertyName("alternating")]
        public bool? Alternating { get; set; } = null;
        [JsonPropertyName("twinkle")]
        public bool? Twinkle { get; set; } = null;
    }

    public class RgblightDefault
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
    }

    public enum RgblightDriver
    {
        apa102,
        custom,
        ws2812,
    }

    public class RgblightLayers
    {
        [JsonPropertyName("blink")]
        public bool? Blink { get; set; } = null;
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("max")]
        public int? Max { get; set; } = null;
        [JsonPropertyName("override_rgb")]
        public bool? OverrideRgb { get; set; } = null;
    }
}
