using System.Text.Json.Serialization;

namespace QmkJson
{
    public class MouseKey
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("delay")]
        public byte? Delay { get; set; } = null;
        [JsonPropertyName("interval")]
        public byte? Interval { get; set; } = null;
        [JsonPropertyName("max_speed")]
        public byte? MaxSpeed { get; set; } = null;
        [JsonPropertyName("time_to_max")]
        public byte? TimeToMax { get; set; } = null;
        [JsonPropertyName("wheel_delay")]
        public byte? WheelDelay { get; set; } = null;
    }
}
