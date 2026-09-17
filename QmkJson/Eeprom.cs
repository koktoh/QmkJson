using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Eeprom
    {
        [JsonPropertyName("driver")]
        public string? Driver { get; set; } = null;
        [JsonPropertyName("wear_leveling")]
        public WearLeveling? WearLeveling { get; set; } = null;
    }

    public class WearLeveling
    {
        [JsonPropertyName("driver")]
        public WearLevelingDriver? Driver { get; set; } = null;
        [JsonPropertyName("backing_size")]
        public uint? BackingSize { get; set; } = null;
        [JsonPropertyName("logical_size")]
        public uint? LogicalSize { get; set; } = null;
    }

    public enum WearLevelingDriver
    {
        none,
        custom,
        embedded_flash,
        legacy,
        rp2040_flash,
        spi_flash,
    }
}
