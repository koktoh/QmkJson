using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Encoder : EncoderConfig
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
    }

    public class EncoderConfig
    {
        [JsonPropertyName("driver")]
        public EncoderDriver? Driver { get; set; } = null;
        [JsonPropertyName("rotary")]
        public IEnumerable<Rotary>? Rotary { get; set; } = null;
    }

    public enum EncoderDriver
    {
        custom,
        quadrature,
    }

    public class Rotary
    {
        [JsonPropertyName("pin_a")]
        public required McuPin PinA { get; set; }
        [JsonPropertyName("pin_b")]
        public required McuPin PinB { get; set; }
        [JsonPropertyName("resolution")]
        public uint? Resolution { get; set; } = null;
    }
}
