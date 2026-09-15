using System.Text.Json.Serialization;
using QmkJson.Definitions;

namespace QmkJson
{
    public class Usb
    {
        [Obsolete($"Use {nameof(DeviceVersion)} instead.")]
        [JsonPropertyName("device_ver")]
        public HexU16? DeviceVer { get; set; } = null;
        [JsonPropertyName("device_version")]
        public Version? DeviceVersion { get; set; } = null;
        [Obsolete($"Use {nameof(Host)}.{nameof(Host.Default)}.{nameof(Host.Default.Nkro)} instead.")]
        [JsonPropertyName("force_nkro")]
        public bool? ForceNkro { get; set; } = null;
        [JsonPropertyName("pid")]
        public HexU16? Pid { get; set; } = null;
        [JsonPropertyName("vid")]
        public HexU16? Vid { get; set; } = null;
        [JsonPropertyName("max_power")]
        public uint? MaxPower { get; set; } = null;
        [JsonPropertyName("no_startup_check")]
        public bool? NoStartupCheck { get; set; } = null;
        [JsonPropertyName("polling_interval")]
        public byte? PollingInterval { get; set; } = null;
        [JsonPropertyName("shared_endpoint")]
        public UsbSharedEndpoint? SharedEndpoint { get; set; } = null;
        [JsonPropertyName("suspend_wakeup_delay")]
        public uint? SuspendWakeupDelay { get; set; } = null;
        [JsonPropertyName("wait_for_enumeration")]
        public bool? WaitForEnumeration { get; set; } = null;
    }

    public class UsbSharedEndpoint
    {
        [JsonPropertyName("keyboard")]
        public bool? Keyboard { get; set; } = null;
        [JsonPropertyName("mouse")]
        public bool? Mouse { get; set; } = null;
    }
}
