using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QmkJson
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class JsonInlineAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal sealed class JsonCompactAttribute : Attribute
    {
    }

    internal class JsonCompactConverter : JsonConverterFactory
    {
        private readonly bool _inline;

        public JsonCompactConverter(bool inline = false)
        {
            this._inline = inline;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsDefined(typeof(JsonCompactAttribute), false);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return (JsonConverter?)Activator.CreateInstance(
            typeof(JsonCompactConverterInner<>).MakeGenericType(typeToConvert),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: [this._inline],
            culture: null);
        }

        private sealed class JsonCompactConverterInner<T> : JsonConverter<T>
        {
            private readonly bool _inline;

            public JsonCompactConverterInner(bool inline = false)
            {
                this._inline = inline;
            }

            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return JsonSerializer.Deserialize<T>(ref reader, this.OverrideOptions(options));
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                var writeOptions = new JsonWriterOptions { Indented = false };

                using var stream = new MemoryStream();
                using var compactWriter = new Utf8JsonWriter(stream, writeOptions);

                JsonSerializer.Serialize(compactWriter, value, this.OverrideOptions(options));
                compactWriter.Flush();

                var indent = this._inline ? string.Empty : this.GetIndent(options, writer.CurrentDepth);

                writer.WriteRawValue(indent + Encoding.UTF8.GetString(stream.ToArray()));
            }

            private string GetIndent(JsonSerializerOptions options, int depth)
            {
                if (!options.WriteIndented) return string.Empty;

                var indentBase = new string(options.IndentCharacter, options.IndentSize);
                var indent = options.NewLine + string.Concat(Enumerable.Repeat(indentBase, depth));

                return indent;
            }

            private JsonSerializerOptions OverrideOptions(JsonSerializerOptions options)
            {
                var overridden = new JsonSerializerOptions(options)
                {
                    WriteIndented = false
                };

                for (int i = overridden.Converters.Count - 1; i >= 0; i--)
                {
                    if (overridden.Converters[i] is JsonCompactConverter)
                    {
                        overridden.Converters.RemoveAt(i);
                    }
                }

                return overridden;
            }
        }
    }
}
