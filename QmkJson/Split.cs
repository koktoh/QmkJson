using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Split
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("bootmagic")]
        public SplitBootmagic? Bootmagic { get; set; } = null;
        [JsonPropertyName("matrix_pins")]
        public SplitRightPins? MatrixPins { get; set; } = null;
        [JsonPropertyName("dip_switch")]
        public SplitRightDipSwitch? DipSwitch { get; set; } = null;
        [JsonPropertyName("encoder")]
        public SplitRightEncoder? Encoder { get; set; } = null;
        [JsonPropertyName("handedness")]
        public SplitHandedness? Handedness { get; set; } = null;
        [Obsolete($"Use {nameof(Split)}.{nameof(Serial)}.{nameof(Serial.Pin)} instead.")]
        [JsonPropertyName("soft_serial_pin")]
        public McuPin? SoftSerialPin { get; set; } = null;
        [Obsolete($"Use {nameof(Split)}.{nameof(Serial)}.{nameof(Serial.Speed)} instead.")]
        [JsonPropertyName("soft_serial_speed")]
        public int? SoftSerialSpeed { get; set; } = null;
        [JsonPropertyName("serial")]
        public SplitSerial? Serial { get; set; } = null;
        [JsonPropertyName("transport")]
        public SplitTransport? Transport { get; set; } = null;
        [JsonPropertyName("usb_detect")]
        public SplitUsbDetect? UsbDetect { get; set; } = null;
        [Obsolete($"Not used for now.")]
        [JsonPropertyName("main")]
        public MainType? Main { get; set; } = null;
        [Obsolete($"Use {nameof(Split)}.{nameof(Handedness)}.{nameof(Handedness.MatrixGrid)} instead.")]
        [JsonPropertyName("matrix_grid")]
        public IEnumerable<McuPin?>? MatrixGrid { get; set; } = null;
    }

    public class SplitBootmagic
    {
        [JsonInline]
        [JsonPropertyName("matrix")]
        public Matrix? Matrix { get; set; } = null;
    }

    public class SplitMatrixPins
    {
        [JsonPropertyName("direct")]
        public IEnumerable<DirectRow>? Direct { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("cols")]
        public IEnumerable<McuPin?>? Cols { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("rows")]
        public IEnumerable<McuPin?>? Rows { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("unused")]
        public IEnumerable<McuPin?>? Unused { get; set; } = null;
    }

    public class SplitRightPins
    {
        [JsonPropertyName("right")]
        public SplitMatrixPins? Right { get; set; } = null;
    }

    public class SplitRightDipSwitch
    {
        [JsonPropertyName("right")]
        public DipSwitchConfig? Right { get; set; } = null;
    }

    public class SplitRightEncoder
    {
        [JsonPropertyName("right")]
        public EncoderConfig? Right { get; set; } = null;
    }

    public class SplitHandedness
    {
        [JsonPropertyName("pin")]
        public McuPin? Pin { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("matrix_grid")]
        public IEnumerable<McuPin?>? MatrixGrid { get; set; } = null;
    }

    public class SplitSerial
    {
        [JsonPropertyName("driver")]
        public SplitSerialDriver? Driver { get; set; } = null;
        [JsonPropertyName("pin")]
        public McuPin? Pin { get; set; } = null;
        [JsonPropertyName("speed")]
        public int? Speed { get; set; } = null;
    }

    public enum SplitSerialDriver
    {
        bitbang,
        usart,
        vendor,
    }

    public class SplitTransport
    {
        [JsonPropertyName("protocol")]
        public SplitTransportProtocol? Protocol { get; set; } = null;
        [JsonPropertyName("sync")]
        public SplitTransportSync? Sync { get; set; } = null;
        [JsonPropertyName("watchdog")]
        public bool? Watchdog { get; set; } = null;
        [JsonPropertyName("watchdog_timeout")]
        public uint? WatchdogTimeout { get; set; } = null;
        [Obsolete($"Use {nameof(Sync)}.{nameof(Sync.MatrixState)} instead.")]
        [JsonPropertyName("sync_matrix_state")]
        public bool? SyncMatrixState { get; set; } = null;
        [Obsolete($"Use {nameof(Sync)}.{nameof(Sync.Modifiers)} instead.")]
        [JsonPropertyName("sync_modifiers")]
        public bool? SyncModifiers { get; set; } = null;
    }

    public enum SplitTransportProtocol
    {
        custom,
        i2c,
        serial,
    }

    public class SplitTransportSync
    {
        [JsonPropertyName("activity")]
        public bool? Activity { get; set; } = null;
        [JsonPropertyName("detected_os")]
        public bool? DetectedOS { get; set; } = null;
        [JsonPropertyName("haptic")]
        public bool? Haptic { get; set; } = null;
        [JsonPropertyName("layer_state")]
        public bool? LayerState { get; set; } = null;
        [JsonPropertyName("indicators")]
        public bool? Indicators { get; set; } = null;
        [JsonPropertyName("matrix_state")]
        public bool? MatrixState { get; set; } = null;
        [JsonPropertyName("modifiers")]
        public bool? Modifiers { get; set; } = null;
        [JsonPropertyName("oled")]
        public bool? Oled { get; set; } = null;
        [JsonPropertyName("st7565")]
        public bool? ST7565 { get; set; } = null;
        [JsonPropertyName("wpm")]
        public bool? WPM { get; set; } = null;
    }

    public class SplitUsbDetect
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("polling_interval")]
        public uint? PollingInterval { get; set; } = null;
        [JsonPropertyName("timeout")]
        public uint? Timeout { get; set; } = null;
    }

    [Obsolete("Not used for now.")]
    public enum MainType
    {
        eeprom,
        left,
        matrix_grid,
        pin,
        right,
    }
}
