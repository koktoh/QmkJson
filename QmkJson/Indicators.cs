using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Indicators
    {
        [JsonPropertyName("caps_lock")]
        public McuPin? CapsLock { get; set; } = null;
        [JsonPropertyName("num_lock")]
        public McuPin? NumLock { get; set; } = null;
        [JsonPropertyName("scroll_lock")]
        public McuPin? ScrollLock { get; set; } = null;
        [JsonPropertyName("compose")]
        public McuPin? Compose { get; set; } = null;
        [JsonPropertyName("kana")]
        public McuPin? Kana { get; set; } = null;
        [JsonPropertyName("on_state")]
        public Bit? OnState { get; set; } = null;
    }
}
