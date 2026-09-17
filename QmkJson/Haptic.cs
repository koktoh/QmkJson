using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Haptic
    {
        [JsonPropertyName("driver")]
        public HapticDriver? Driver { get; set; } = null;
    }

    public enum HapticDriver
    {
        drv2605l,
        solenoid,
    }
}
