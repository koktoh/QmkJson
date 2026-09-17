using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class WS2812
    {
        [JsonPropertyName("driver")]
        public WS2812Driver? Driver { get; set; } = null;
        [JsonPropertyName("pin")]
        public McuPin? Pin { get; set; } = null;
        [JsonPropertyName("rgbw")]
        public bool? Rgbw { get; set; } = null;
        [JsonPropertyName("i2c_address")]
        public HexU8? I2cAddress { get; set; } = null;
        [JsonPropertyName("i2c_timeout")]
        public uint? I2cTimeout { get; set; } = null;
    }

    public enum WS2812Driver
    {
        bitbang,
        custom,
        i2c,
        pwm,
        spi,
        vendor,
    }
}
