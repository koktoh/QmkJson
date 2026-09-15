using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Bluetooth
    {
        [JsonPropertyName("driver")]
        public BluetoothDriver? Driver { get; set; } = null;
    }

    public enum BluetoothDriver
    {
        bluefruit_le,
        custom,
        rn42,
    }
}
