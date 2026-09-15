namespace QmkJson.Definitions
{
    [System.Text.Json.Serialization.JsonConverter(typeof(HexU16JsonConverter))]
    public readonly struct HexU16 : IHexNumber<ushort>
    {
        public ushort Value { get; } = 0;

        public HexU16() { }
        public HexU16(ushort value)
        {
            this.Value = value;
        }
        public HexU16(string value)
        {
            this.Value = HexConverter.Convert<ushort>(value);
        }

        public override string ToString()
        {
            return this.ToHexString(4);
        }

        public static implicit operator ushort(HexU16 value) => value.Value;
        public static implicit operator HexU16(ushort value) => new(value);
    }

    internal sealed class HexU16JsonConverter : System.Text.Json.Serialization.JsonConverter<HexU16>
    {
        public override HexU16 Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                System.Text.Json.JsonTokenType.Number => new HexU16(reader.GetUInt16()),
                System.Text.Json.JsonTokenType.String => new HexU16(reader.GetString() ?? string.Empty),
                _ => throw new System.Text.Json.JsonException($"Unexpected token parsing HexU16. Expected Number or HEX string, got {reader.TokenType}."),
            };

        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, HexU16 value, System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
