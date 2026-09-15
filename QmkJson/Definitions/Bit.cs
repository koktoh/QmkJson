namespace QmkJson.Definitions
{
    [System.Text.Json.Serialization.JsonConverter(typeof(BitJsonConverter))]
    public readonly struct Bit
    {
        public bool Value { get; } = false;

        public Bit() { }
        public Bit(bool value)
        {
            this.Value = value;
        }
        public Bit(sbyte value) : this((long)value) { }
        public Bit(byte value) : this((ulong)value) { }
        public Bit(short value) : this((long)value) { }
        public Bit(ushort value) : this((ulong)value) { }
        public Bit(int value) : this((long)value) { }
        public Bit(uint value) : this((ulong)value) { }
        public Bit(long value)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 1);

            this.Value = value != 0;
        }
        public Bit(ulong value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan<ulong>(value, 1);

            this.Value = value != 0;
        }
        public Bit(nint value) : this((long)value) { }
        public Bit(nuint value) : this((ulong)value) { }

        public static implicit operator Bit(bool value) => new(value);
        public static implicit operator Bit(sbyte value) => new(value);
        public static implicit operator Bit(byte value) => new(value);
        public static implicit operator Bit(short value) => new(value);
        public static implicit operator Bit(ushort value) => new(value);
        public static implicit operator Bit(int value) => new(value);
        public static implicit operator Bit(uint value) => new(value);
        public static implicit operator Bit(long value) => new(value);
        public static implicit operator Bit(ulong value) => new(value);
        public static implicit operator Bit(nint value) => new(value);
        public static implicit operator Bit(nuint value) => new(value);

        public static implicit operator bool(Bit value) => value.Value;
        public static implicit operator sbyte(Bit value) => (sbyte)(value.Value ? 1 : 0);
        public static implicit operator byte(Bit value) => (byte)(value.Value ? 1 : 0);
        public static implicit operator short(Bit value) => (short)(value.Value ? 1 : 0);
        public static implicit operator ushort(Bit value) => (ushort)(value.Value ? 1 : 0);
        public static implicit operator int(Bit value) => (int)(value.Value ? 1 : 0);
        public static implicit operator uint(Bit value) => (uint)(value.Value ? 1 : 0);
        public static implicit operator long(Bit value) => (long)(value.Value ? 1 : 0);
        public static implicit operator ulong(Bit value) => (ulong)(value.Value ? 1 : 0);
        public static implicit operator nint(Bit value) => (nint)(value.Value ? 1 : 0);
        public static implicit operator nuint(Bit value) => (nuint)(value.Value ? 1 : 0);

        public static bool operator ==(Bit left, Bit right) => left.Value == right.Value;
        public static bool operator !=(Bit left, Bit right) => left.Value != right.Value;

        public override bool Equals(object? obj) => obj is Bit other && this.Value == other.Value;
        public override int GetHashCode() => this.Value ? 1 : 0;
        public override string ToString() => this.Value ? "1" : "0";
    }

    internal sealed class BitJsonConverter : System.Text.Json.Serialization.JsonConverter<Bit>
    {
        public override Bit Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                System.Text.Json.JsonTokenType.Number => new Bit(reader.GetInt64()),
                System.Text.Json.JsonTokenType.True => new Bit(true),
                System.Text.Json.JsonTokenType.False => new Bit(false),
                _ => throw new System.Text.Json.JsonException($"Unexpected token parsing Bit. Expected Number or Boolean, got {reader.TokenType}."),
            };
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, Bit value, System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value ? 1 : 0);
        }
    }
}
