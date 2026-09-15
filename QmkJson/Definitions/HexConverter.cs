using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace QmkJson.Definitions
{
    internal static partial class HexConverter
    {
        public static T Convert<T>(string value)
            where T : INumber<T>
        {
            if (string.IsNullOrEmpty(value)) return T.Zero;

            if (IntegerRegex().IsMatch(value))
            {
                return T.Parse(value, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
            }
            else if (HexRegex().IsMatch(value))
            {
                var s = value.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? value[2..] : value;

                return T.Parse(s, NumberStyles.HexNumber, NumberFormatInfo.InvariantInfo);
            }

            throw new FormatException($"The input string '{value}' was not in a correct format.");
        }

        public static string ToHexString<T>(this IHexNumber<T> number, int digit = 0)
            where T : INumber<T>
        {
            return $"0x{number.Value.ToString($"x{digit}", NumberFormatInfo.InvariantInfo).ToUpperInvariant()}";
        }

        [GeneratedRegex(@"^[0-9]+$")]
        private static partial Regex IntegerRegex();
        [GeneratedRegex(@"^(0x)?[0-9A-F]+$", RegexOptions.IgnoreCase)]
        private static partial Regex HexRegex();
    }
}
