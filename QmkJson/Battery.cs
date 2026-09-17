using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Battery
    {
        [JsonPropertyName("driver")]
        public BatteryDriver? Driver { get; set; } = null;
        [JsonPropertyName("adc")]
        public Adc? Adc { get; set; } = null;
        [JsonPropertyName("sample_interval")]
        public int? SampleInterval { get; set; } = null;
    }

    public enum BatteryDriver
    {
        adc,
        custom,
        vendor,
    }

    public class Adc
    {
        [JsonPropertyName("pin")]
        public McuPin? Pin { get; set; } = null;
        [JsonPropertyName("reference_voltage")]
        public int? ReferenceVoltage { get; set; } = null;
        [JsonPropertyName("divider_r1")]
        public int? DividerR1 { get; set; } = null;
        [JsonPropertyName("divider_r2")]
        public int? DividerR2 { get; set; } = null;
        [JsonPropertyName("resolution")]
        public int? Resolution { get; set; } = null;
    }
}
