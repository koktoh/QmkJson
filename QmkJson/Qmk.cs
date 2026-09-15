using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Qmk
    {
        [JsonPropertyName("keys_per_scan")]
        public byte? KeysPerScan { get; set; } = null;
        [JsonPropertyName("tap_keycode_delay")]
        public uint? TapKeycodeDelay { get; set; } = null;
        [JsonPropertyName("tap_capslock_delay")]
        public uint? TapCapslockDelay { get; set; } = null;
        [JsonPropertyName("locking")]
        public QmkLocking? Locking { get; set; } = null;
    }

    public class QmkLocking
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("resync")]
        public bool? Resync { get; set; } = null;
    }
}
