using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Features
    {
        [JsonPropertyName("audio")]
        public bool? Audio { get; set; } = null;
        [JsonPropertyName("backlight")]
        public bool? Backlight { get; set; } = null;
        [JsonPropertyName("battery")]
        public bool? Battery { get; set; } = null;
        [JsonPropertyName("bluetooth")]
        public bool? Bluetooth { get; set; } = null;
        [JsonPropertyName("bootmagic")]
        public bool? Bootmagic { get; set; } = null;
        [JsonPropertyName("caps_word")]
        public bool? CapsWord { get; set; } = null;
        [JsonPropertyName("command")]
        public bool? Command { get; set; } = null;
        [JsonPropertyName("console")]
        public bool? Console { get; set; } = null;
        [JsonPropertyName("dip_switch")]
        public bool? DipSwitch { get; set; } = null;
        [JsonPropertyName("dynamic_keymap")]
        public bool? DynamicKeymap { get; set; } = null;
        [JsonPropertyName("encoder")]
        public bool? Encoder { get; set; } = null;
        [JsonPropertyName("extrakey")]
        public bool? Extrakey { get; set; } = null;
        [JsonPropertyName("haptic")]
        public bool? Haptic { get; set; } = null;
        [JsonPropertyName("joystick")]
        public bool? Joystick { get; set; } = null;
        [JsonPropertyName("layer_lock")]
        public bool? LayerLock { get; set; } = null;
        [JsonPropertyName("led_matrix")]
        public bool? LedMatrix { get; set; } = null;
        [JsonPropertyName("mousekey")]
        public bool? Mousekey { get; set; } = null;
        [JsonPropertyName("nkro")]
        public bool? Nkro { get; set; } = null;
        [JsonPropertyName("oled")]
        public bool? Oled { get; set; } = null;
        [JsonPropertyName("ps2")]
        public bool? Ps2 { get; set; } = null;
        [JsonPropertyName("rgb_matrix")]
        public bool? RgbMatrix { get; set; } = null;
        [JsonPropertyName("rgblight")]
        public bool? Rgblight { get; set; } = null;
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionFeatures { get; set; } = [];
    }
}
