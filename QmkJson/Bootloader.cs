using System.Text.Json.Serialization;

namespace QmkJson
{
    public enum Bootloader
    {
        [JsonStringEnumMemberName("apm32-dfu")]
        apm32_dfu,
        [JsonStringEnumMemberName("at32-dfu")]
        at32_dfu,
        [JsonStringEnumMemberName("atmel-dfu")]
        atmel_dfu,
        bootloadhid,
        caterina,
        custom,
        [JsonStringEnumMemberName("gd32v-dfu")]
        gd32v_dfu,
        halfkay,
        kiibohd,
        [JsonStringEnumMemberName("lufa-dfu")]
        lufa_dfu,
        [JsonStringEnumMemberName("lufa-ms")]
        lufa_ms,
        [JsonStringEnumMemberName("md-boot")]
        md_boot,
        [JsonStringEnumMemberName("qmk-dfu")]
        qmk_dfu,
        [JsonStringEnumMemberName("qmk-hid")]
        qmk_hid,
        rp2040,
        [JsonStringEnumMemberName("stm32-dfu")]
        stm32_dfu,
        stm32duino,
        tinyuf2,
        uf2boot,
        unknown,
        usbasploader,
        [JsonStringEnumMemberName("wb32-dfu")]
        wb32_dfu,
    }
}
