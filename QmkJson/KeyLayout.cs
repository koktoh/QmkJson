using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class KeyLayout
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; } = null;
        [JsonPropertyName("c_macro")]
        public bool? CMacro { get; set; } = null;
        [JsonPropertyName("json_layout")]
        public bool? JsonLayout { get; set; } = null;
        [JsonPropertyName("layout")]
        public IEnumerable<Key>? Layout { get; set; } = null;
    }

    public enum Hand
    {
        [JsonStringEnumMemberName("L")]
        Left,
        [JsonStringEnumMemberName("R")]
        Right,
        [JsonStringEnumMemberName("*")]
        Aster,
    }

    [JsonCompact]
    public class Key
    {
        [JsonPropertyName("encoder")]
        public int? Encoder { get; set; } = null;
        [JsonPropertyName("label")]
        public string? Label { get; set; } = null;
        [JsonPropertyName("matrix")]
        public Matrix? Matrix { get; set; } = null;
        [JsonPropertyName("r")]
        public double? Rotation { get; set; } = null;
        [JsonPropertyName("rx")]
        public double? RotOriginX { get; set; } = null;
        [JsonPropertyName("ry")]
        public double? RotOriginY { get; set; } = null;
        [JsonPropertyName("h")]
        public double? Height { get; set; } = null;
        [JsonPropertyName("w")]
        public double? Width { get; set; } = null;
        [JsonPropertyName("x")]
        public required double X { get; set; } = 0;
        [JsonPropertyName("y")]
        public required double Y { get; set; } = 0;
        [JsonPropertyName("hand")]
        public Hand? Hand { get; set; } = null;
    }
}
