namespace QmkJson.Lighting
{
    [Flags]
    public enum LightingFlag : byte
    {
        None = 0x00,
        All = 0xFF,
        Modifier = 0x01,
        Underglow = 0x02,
        Keylight = 0x04,
        Indicator = 0x08,
    }
}
