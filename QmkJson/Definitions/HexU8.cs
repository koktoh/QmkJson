namespace QmkJson.Definitions
{
    [System.Text.Json.Serialization.JsonConverter(typeof(HexU8JsonConverter))]
    public readonly struct HexU8 : IHexNumber<byte>
    {
        public byte Value { get; } = 0;

        public HexU8() { }
        public HexU8(byte value)
        {
            this.Value = value;
        }
        public HexU8(string value)
        {
            this.Value = HexConverter.Convert<byte>(value);
        }

        public override string ToString()
        {
            return this.ToHexString(2);
        }

        public static implicit operator byte(HexU8 value) => value.Value;
        public static implicit operator HexU8(byte value) => new(value);
    }

    internal sealed class HexU8JsonConverter : System.Text.Json.Serialization.JsonConverter<HexU8>
    {
        public override HexU8 Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                System.Text.Json.JsonTokenType.Number => new HexU8(reader.GetByte()),
                System.Text.Json.JsonTokenType.String => new HexU8(reader.GetString() ?? string.Empty),
                _ => throw new System.Text.Json.JsonException($"Unexpected token parsing HexU8. Expected Number or HEX string, got {reader.TokenType}."),
            };

        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, HexU8 value, System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
