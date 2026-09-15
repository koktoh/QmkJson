using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class DipSwitch : DipSwitchConfig
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("matrix_grid")]
        public IEnumerable<Matrix>? MatrixGrid { get; set; } = null;
    }

    public class DipSwitchConfig
    {
        [JsonInline]
        [JsonPropertyName("pins")]
        public IEnumerable<McuPin?>? Pins { get; set; } = null;
    }
}
