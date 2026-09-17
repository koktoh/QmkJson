using System.Text.Json.Serialization;

namespace QmkJson.Definitions
{
    public class KeycodeDecl
    {
        [JsonPropertyName("key")]
        public required string Key { get; set; } = string.Empty;
        [JsonPropertyName("label")]
        public string? Label { get; set; } = null;
        [JsonInline]
        [JsonPropertyName("aliases")]
        public IEnumerable<string>? Aliases { get; set; } = null;

        public KeycodeDecl() { }
        public KeycodeDecl(string key)
        {
            this.Key = key;
        }
    }
}
