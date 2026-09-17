namespace QmkJson.Definitions
{
    [JsonCompact]
    [System.Text.Json.Serialization.JsonConverter(typeof(SplitCountJsonConverter))]
    public struct SplitCount
    {
        public int Left { get; set; } = 0;
        public int Right { get; set; } = 0;

        public SplitCount() { }
        public SplitCount(int left, int right)
        {
            this.Left = left;
            this.Right = right;
        }
    }

    internal sealed class SplitCountJsonConverter : System.Text.Json.Serialization.JsonConverter<SplitCount>
    {
        public override SplitCount Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        {
            if (reader.TokenType != System.Text.Json.JsonTokenType.StartArray)
            {
                throw new System.Text.Json.JsonException("Expected start of array.");
            }
            reader.Read();
            int left = reader.GetInt32();
            reader.Read();
            int right = reader.GetInt32();
            reader.Read();
            if (reader.TokenType != System.Text.Json.JsonTokenType.EndArray)
            {
                throw new System.Text.Json.JsonException("Expected end of array.");
            }
            return new SplitCount(left, right);
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, SplitCount value, System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Left);
            writer.WriteNumberValue(value.Right);
            writer.WriteEndArray();
        }
    }
}
