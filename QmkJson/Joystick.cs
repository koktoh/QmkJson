using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Joystick
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = null;
        [JsonPropertyName("driver")]
        public string? Driver { get; set; } = null;
        [JsonPropertyName("button_count")]
        public uint? ButtonCount { get; set; } = null;
        [JsonPropertyName("axis_resolution")]
        public uint? AxisResolution { get; set; } = null;
        [JsonPropertyName("axes")]
        public JoystickAxes? Axes { get; set; } = null;
    }

    [JsonConverter(typeof(JoystickAxisJsonConverter))]
    public class JoystickAxis
    {
        public McuPin? InputPin { get; set; } = null;
        public uint? Low { get; set; } = null;
        public uint? Rest { get; set; } = null;
        public uint? High { get; set; } = null;
        public bool IsVirtual { get; set; } = false;
    }

    public class JoystickAxes
    {
        [JsonPropertyName("x")]
        public JoystickAxis? X { get; set; } = null;
        [JsonPropertyName("y")]
        public JoystickAxis? Y { get; set; } = null;
        [JsonPropertyName("z")]
        public JoystickAxis? Z { get; set; } = null;
        [JsonPropertyName("rx")]
        public JoystickAxis? RX { get; set; } = null;
        [JsonPropertyName("ry")]
        public JoystickAxis? RY { get; set; } = null;
        [JsonPropertyName("rz")]
        public JoystickAxis? RZ { get; set; } = null;
    }

    internal sealed class JoystickAxisJsonConverter : JsonConverter<JoystickAxis>
    {
        private const string VIRTUAL = "virtual";

        public override JoystickAxis? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();

                if (value != VIRTUAL) throw new JsonException($"Invalid joystick axis value: {value}");

                return new JoystickAxis
                {
                    IsVirtual = true,
                };

            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var axis = JsonSerializer.Deserialize<JoystickAxisData>(ref reader, options);

                if (axis is null) return null;

                return new JoystickAxis
                {
                    InputPin = axis.InputPin,
                    Low = axis.Low,
                    Rest = axis.Rest,
                    High = axis.High,
                };
            }

            throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, JoystickAxis value, JsonSerializerOptions options)
        {
            if (value.IsVirtual)
            {
                writer.WriteStringValue(VIRTUAL);
            }
            else
            {
                var axis = new JoystickAxisData
                {
                    InputPin = value.InputPin,
                    Low = value.Low,
                    Rest = value.Rest,
                    High = value.High,
                };

                JsonSerializer.Serialize(writer, axis, options);
            }
        }

        private sealed class JoystickAxisData
        {
            [JsonPropertyName("input_pin")]
            public McuPin? InputPin { get; set; } = null;
            [JsonPropertyName("low")]
            public uint? Low { get; set; } = null;
            [JsonPropertyName("rest")]
            public uint? Rest { get; set; } = null;
            [JsonPropertyName("high")]
            public uint? High { get; set; } = null;
        }
    }
}
