using System.Text.Json.Serialization;

namespace QmkJson
{
    public class Build
    {
        [JsonPropertyName("debounce_type")]
        public DebounceType? DebounceType { get; set; } = null;
        [JsonPropertyName("firmware_format")]
        public FirmwareFormat? FirmwareFormat { get; set; } = null;
        [JsonPropertyName("lto")]
        public bool? Lto { get; set; } = null;
    }

    public enum DebounceType
    {
        asym_eager_defer_pk,
        custom,
        sym_defer_g,
        sym_defer_pk,
        sym_defer_pr,
        sym_eager_pk,
        sym_eager_pr,
    }

    public enum FirmwareFormat
    {
        bin,
        hex,
        uf2,
    }
}
