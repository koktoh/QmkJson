namespace QmkJson.Definitions
{
    [JsonCompact]
    [System.Text.Json.Serialization.JsonConverter(typeof(MatrixJsonConverter))]
    public struct Matrix
    {
        public uint Row { get; set; } = 0;
        public uint Col { get; set; } = 0;

        public Matrix() { }
        public Matrix(uint row, uint col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    internal sealed class MatrixJsonConverter : System.Text.Json.Serialization.JsonConverter<Matrix>
    {
        public override Matrix Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        {
            if (reader.TokenType != System.Text.Json.JsonTokenType.StartArray)
            {
                throw new System.Text.Json.JsonException("Expected start of array.");
            }
            reader.Read();
            uint row = reader.GetUInt32();
            reader.Read();
            uint col = reader.GetUInt32();
            reader.Read();
            if (reader.TokenType != System.Text.Json.JsonTokenType.EndArray)
            {
                throw new System.Text.Json.JsonException("Expected end of array.");
            }
            return new Matrix(row, col);
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, Matrix value, System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Row);
            writer.WriteNumberValue(value.Col);
            writer.WriteEndArray();
        }
    }
}
