using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Keyboard
    {
        [JsonPropertyName("keyboard_name")]
        public string? KeyboardName { get; set; } = null;
        [JsonPropertyName("keyboard_folder")]
        public string? KeyboardFolder { get; set; } = null;
        [JsonPropertyName("maintainer")]
        public string? Maintainer { get; set; } = null;
        [JsonPropertyName("manufacturer")]
        public string? Manufacturer { get; set; } = null;
        [JsonPropertyName("url")]
        public string? Url { get; set; } = null;
        [JsonPropertyName("development_board")]
        public DevelopmentBoard? DevelopmentBoard { get; set; } = null;
        [JsonPropertyName("pin_compatible")]
        public PinCompatible? PinCompatible { get; set; } = null;
        [JsonPropertyName("processor")]
        public Processor? Processor { get; set; } = null;
        [JsonPropertyName("apa102")]
        public Apa102? Apa102 { get; set; } = null;
        [JsonPropertyName("audio")]
        public Audio? Audio { get; set; } = null;
        [JsonPropertyName("backlight")]
        public Backlight? Backlight { get; set; } = null;
        [JsonPropertyName("battery")]
        public Battery? Battery { get; set; } = null;
        [JsonPropertyName("bluetooth")]
        public Bluetooth? Bluetooth { get; set; } = null;
        [JsonPropertyName("bootmagic")]
        public Bootmagic? Bootmagic { get; set; } = null;
        [JsonPropertyName("board")]
        public string? Board { get; set; } = null;
        [JsonPropertyName("bootloader")]
        public Bootloader? Bootloader { get; set; } = null;
        [JsonPropertyName("bootloader_instructions")]
        public string? BootloaderInstructions { get; set; } = null;
        [JsonPropertyName("build")]
        public Build? Build { get; set; } = null;
        [JsonPropertyName("diode_direction")]
        public DiodeDirection? DiodeDirection { get; set; } = null;
        [JsonPropertyName("debounce")]
        public uint? Debounce { get; set; } = null;
        [JsonPropertyName("caps_word")]
        public CapsWord? CapsWord { get; set; } = null;
        [JsonPropertyName("combo")]
        public Combo? Combo { get; set; } = null;
        [JsonPropertyName("community_layouts")]
        public IEnumerable<string>? CommunityLayouts { get; set; } = null;
        [JsonPropertyName("dip_switch")]
        public DipSwitch? DipSwitch { get; set; } = null;
        [JsonPropertyName("dynamic_keymap")]
        public DynamicKeymap? DynamicKeymap { get; set; } = null;
        [JsonPropertyName("eeprom")]
        public Eeprom? Eeprom { get; set; } = null;
        [JsonPropertyName("encoder")]
        public Encoder? Encoder { get; set; } = null;
        [JsonPropertyName("features")]
        public Features? Features { get; set; } = null;
        [JsonPropertyName("indicators")]
        public Indicators? Indicators { get; set; } = null;
        [JsonPropertyName("joystick")]
        public Joystick? Joystick { get; set; } = null;
        [JsonPropertyName("keycodes")]
        public IEnumerable<KeycodeDecl>? Keycodes { get; set; } = null;
        [JsonPropertyName("layer_lock")]
        public LayerLock? LayerLock { get; set; } = null;
        [JsonPropertyName("layout_aliases")]
        public IDictionary<string, string>? LayoutAliases { get; set; } = null;
        [JsonPropertyName("layouts")]
        public IDictionary<string, KeyLayout>? Layouts { get; set; } = null;
        [JsonPropertyName("haptic")]
        public Haptic? Haptic { get; set; } = null;
        [JsonPropertyName("host")]
        public Host? Host { get; set; } = null;
        [JsonPropertyName("leader_key")]
        public LeaderKey? LeaderKey { get; set; } = null;
        [JsonPropertyName("matrix_pins")]
        public MatrixPins? MatrixPins { get; set; } = null;
        [JsonPropertyName("modules")]
        public IEnumerable<string>? Modules { get; set; } = null;
        [JsonPropertyName("mouse_key")]
        public MouseKey? MouseKey { get; set; } = null;
        [JsonPropertyName("oneshot")]
        public Oneshot? Oneshot { get; set; } = null;
        [JsonPropertyName("led_matrix")]
        public LedMatrix? LedMatrix { get; set; } = null;
        [JsonPropertyName("rgb_matrix")]
        public RgbMatrix? RgbMatrix { get; set; } = null;
        [JsonPropertyName("rgblight")]
        public Rgblight? Rgblight { get; set; } = null;
        [JsonPropertyName("secure")]
        public Secure? Secure { get; set; } = null;
        [JsonPropertyName("stenography")]
        public Stenography? Stenography { get; set; } = null;
        [JsonPropertyName("ps2")]
        public Ps2? Ps2 { get; set; } = null;
        [JsonPropertyName("split")]
        public Split? Split { get; set; } = null;
        [JsonPropertyName("tags")]
        public IEnumerable<string>? Tags { get; set; } = null;
        [JsonPropertyName("tapping")]
        public Tapping? Tapping { get; set; } = null;
        [JsonPropertyName("usb")]
        public Usb? Usb { get; set; } = null;
        [JsonPropertyName("qmk")]
        public Qmk? Qmk { get; set; } = null;
        [JsonPropertyName("qmk_lufa_bootloader")]
        public QmkLufaBootloader? QmkLufaBootloader { get; set; } = null;
        [JsonPropertyName("ws2812")]
        public WS2812? WS2812 { get; set; } = null;
    }
}
