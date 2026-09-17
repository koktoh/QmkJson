using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class MatrixPins
    {
        [JsonPropertyName("custom")]
        public bool? Custom { get; set; } = null;
        [JsonPropertyName("custom_lite")]
        public bool? CustomLite { get; set; } = null;
        [JsonPropertyName("ghost")]
        public bool? Ghost { get; set; } = null;
        [JsonPropertyName("input_pressed_state")]
        public uint? InputPressedState { get; set; } = null;
        [JsonPropertyName("io_delay")]
        public uint? IODelay { get; set; } = null;
        [JsonPropertyName("masked")]
        public bool? Masked { get; set; } = null;
        [JsonPropertyName("direct")]
        public IEnumerable<DirectRow>? Direct { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("cols")]
        public IEnumerable<McuPin?>? Cols { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("rows")]
        public IEnumerable<McuPin?>? Rows { get; set; } = null;
    }

    [JsonCompact]
    public class DirectRow : List<McuPin?>
    {
        public DirectRow() : base() { }
        public DirectRow(IEnumerable<McuPin?> collection) : base(collection) { }
        public DirectRow(int capacity) : base(capacity) { }
    }
}
