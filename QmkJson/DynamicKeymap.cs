using System.Text.Json.Serialization;

namespace QmkJson
{
    public class DynamicKeymap
    {
        [JsonPropertyName("eeprom_max_addr")]
        public uint? EepromMaxAddr { get; set; } = null;
        [JsonPropertyName("layer_count")]
        public uint? LayerCount { get; set; } = null;
    }
}
