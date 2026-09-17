using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace QmkJson
{
    public static class QmkJsonSerializer
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            IndentSize = 4,
            NewLine = "\n",
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            ReadCommentHandling = JsonCommentHandling.Skip,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            AllowTrailingCommas = true,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        };

        static QmkJsonSerializer()
        {
            _options.Converters.Add(new JsonCompactConverter());
            _options.Converters.Add(new JsonStringEnumConverter());

            _options.TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                .WithAddedModifier(typeInfo =>
                {
                    foreach (var property in typeInfo.Properties)
                    {
                        if (property.AttributeProvider?.IsDefined(typeof(JsonInlineAttribute), false) ?? false)
                        {
                            property.CustomConverter = new JsonCompactConverter(true);
                        }
                    }
                });
        }

        public static string Serialize(Keyboard keyboard)
        {
            return JsonSerializer.Serialize(keyboard, _options);
        }

        public static Keyboard Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Keyboard>(json, _options) ?? throw new JsonException("The JSON does not contain a valid QMK keyboard definition.");
        }
    }
}
