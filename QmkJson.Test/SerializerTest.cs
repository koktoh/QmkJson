using AwesomeAssertions;
using QmkJson.Definitions;
using QmkJson.Lighting;

namespace QmkJson.Test
{
    public class SerializerTest
    {
        [Fact]
        public void SerializeTest()
        {
            var kbd = new Keyboard
            {
                KeyboardName = "Test Keyboard",
                KeyboardFolder = "keyboard_folder",
                Maintainer = "anonymas",
                Manufacturer = "John Due",
                Url = "https://www.example.com",
                DevelopmentBoard = DevelopmentBoard.promicro_rp2040,
                PinCompatible = PinCompatible.elite_c,
                Processor = Processor.RP2040,
                Apa102 = new Apa102
                {
                    ClockPin = McuPin.A0,
                    DataPin = McuPin.A1,
                    DefaultBrightness = 100,
                },
                Audio = new Audio
                {
                    Default = new AudioDefault
                    {
                        Clicky = false,
                        On = true,
                    },
                    Driver = AudioDriver.dac_basic,
                    MacroBeep = true,
                    Pins = [McuPin.A2, McuPin.A3, McuPin.A4],
                    PowerControl = new AudioPowerControl
                    {
                        OnState = 1,
                        Pin = McuPin.A5,
                    },
                    Voices = false,
                },
                Backlight = new Backlight
                {
                    Driver = BacklightDriver.pwm,
                    Default = new BacklightDefault
                    {
                        On = true,
                        Breathing = true,
                        Brightness = 80,
                    },
                    Breathing = true,
                    BreathingPeriod = 90,
                    Levels = 4,
                    MaxBrightness = 120,
                    Pin = McuPin.A6,
                    Pins = [McuPin.A7, McuPin.A8, McuPin.A9, McuPin.A10],
                    OnState = 0,
                    AsCapsLock = false,
                },
                Battery = new Battery
                {
                    Driver = BatteryDriver.adc,
                    Adc = new Adc
                    {
                        Pin = McuPin.A11,
                        ReferenceVoltage = 5,
                        DividerR1 = 25,
                        DividerR2 = 15,
                        Resolution = 1024,
                    },
                    SampleInterval = 68,
                },
                Bluetooth = new Bluetooth
                {
                    Driver = BluetoothDriver.rn42,
                },
                Bootmagic = new Bootmagic
                {
                    Enabled = true,
                    Matrix = new Matrix(0, 1),
                },
                Board = "something_board",
                Bootloader = Bootloader.rp2040,
                BootloaderInstructions = "Push the reset button on the bottom.",
                Build = new Build
                {
                    DebounceType = DebounceType.sym_defer_g,
                    FirmwareFormat = FirmwareFormat.uf2,
                    Lto = true,
                },
                DiodeDirection = DiodeDirection.COL2ROW,
                Debounce = 3,
                CapsWord = new CapsWord
                {
                    Enabled = true,
                    BothShiftsTurnsOn = true,
                    DoubleTapShiftTurnsOn = true,
                    IdleTimeout = 10,
                    InvertOnShift = false,
                },
                Combo = new Combo
                {
                    Count = 2,
                    Term = 20,
                },
                CommunityLayouts = ["LAYOUT_3x4", "LAYOUT_3x5", "LAYOUT_3x6"],
                DipSwitch = new DipSwitch
                {
                    Enabled = true,
                    Pins = [McuPin.A12, McuPin.A13, McuPin.A14, McuPin.A15],
                    MatrixGrid = [new Matrix(0, 1), new Matrix(2, 3), new Matrix(4, 5)],
                },
                DynamicKeymap = new DynamicKeymap
                {
                    EepromMaxAddr = 0xFFFF,
                    LayerCount = 28,
                },
                Eeprom = new Eeprom
                {
                    Driver = "some_driver",
                    WearLeveling = new WearLeveling
                    {
                        Driver = WearLevelingDriver.rp2040_flash,
                        BackingSize = 4096,
                        LogicalSize = 8192,
                    },
                },
                Encoder = new Encoder
                {
                    Enabled = true,
                    Driver = EncoderDriver.quadrature,
                    Rotary =
                    [
                        new Rotary
                        {
                            PinA = McuPin.A16,
                            PinB = McuPin.A15,
                            Resolution = 4
                        },
                        new Rotary
                        {
                            PinA = McuPin.A17,
                            PinB = McuPin.A18,
                        },
                        new Rotary
                        {
                            PinA = McuPin.A19,
                            PinB = McuPin.A20,
                            Resolution = 8,
                        },
                    ]
                },
                Features = new Features
                {
                    Audio = true,
                    Backlight = true,
                    Battery = true,
                    Bluetooth = true,
                    Bootmagic = true,
                    CapsWord = true,
                    Command = true,
                    Console = true,
                    DipSwitch = true,
                    DynamicKeymap = true,
                    Encoder = true,
                    Extrakey = true,
                    Haptic = true,
                    Joystick = true,
                    LayerLock = true,
                    LedMatrix = true,
                    Mousekey = true,
                    Nkro = true,
                    Oled = true,
                    Ps2 = true,
                    RgbMatrix = true,
                    Rgblight = true,
                    ExtensionFeatures = new Dictionary<string, object>
                    {
                        { "feature1", true },
                        { "feature2", true },
                        { "feature3", false },
                        { "feature4", true },
                        { "feature5", true },
                    },
                },
                Indicators = new Indicators
                {
                    CapsLock = McuPin.B0,
                    NumLock = McuPin.B1,
                    ScrollLock = McuPin.B2,
                    Compose = McuPin.B3,
                    Kana = McuPin.B4,
                    OnState = 0,
                },
                Joystick = new Joystick
                {
                    Enabled = true,
                    Driver = "joystick_driver",
                    ButtonCount = 28,
                    AxisResolution = 6,
                    Axes = new JoystickAxes
                    {
                        X = new JoystickAxis
                        {
                            InputPin = McuPin.B5,
                            Low = 0,
                            Rest = 127,
                            High = 255,
                        },
                        Y = new JoystickAxis
                        {
                            InputPin = McuPin.B6,
                            Low = 10,
                            Rest = 255,
                            High = 500,
                        },
                        Z = new JoystickAxis
                        {
                            InputPin = McuPin.B7,
                            Low = 50,
                            Rest = 512,
                            High = 1000,
                        },
                        RX = new JoystickAxis
                        {
                            IsVirtual = true,
                        },
                        RY = new JoystickAxis
                        {
                            IsVirtual = true,
                        },
                        RZ = new JoystickAxis
                        {
                            IsVirtual = true,
                        },
                    },
                },
                Keycodes =
                [
                    new KeycodeDecl
                    {
                        Key = "MACRO1",
                        Label = "Macro 1",
                        Aliases = ["MCR1"],
                    },
                    new KeycodeDecl
                    {
                        Key = "MACRO2",
                        Label = "Macro 2",
                        Aliases = ["MCR2"],
                    },
                    new KeycodeDecl
                    {
                        Key = "SUPER_AMAGING_KEY_CODE",
                        Label = "Amaging",
                        Aliases = ["SAKC", "SPR_AMG"],
                    },
                ],
                LayerLock = new LayerLock
                {
                    Timeout = 500,
                },
                LayoutAliases = new Dictionary<string, string>
                {
                    { "LAYOUT", "LAYOUT_a" },
                },
                Layouts = new Dictionary<string, KeyLayout>
                {
                    {
                        "LAYOUT_a",
                        new KeyLayout
                        {
                            Layout =
                            [
                                new Key { Encoder = 0, Label = "ESC", Matrix = new Matrix(0, 1), X = 0, Y = 0},
                                new Key { Label = "1", Matrix = new Matrix(0, 2), X = 1, Y = 0},
                                new Key { Label = "2", Matrix = new Matrix(0, 3), Rotation = 10, RotOriginX = 1, RotOriginY = 0, X = 2, Y = 0},
                                new Key { Label = "3", Matrix = new Matrix(0, 2), X = 3, Y = 0, Width = 1.25, Height = 2, Hand = Hand.Left},
                                new Key { Label = "4", Matrix = new Matrix(0, 3), Rotation = -10, RotOriginX = 3, RotOriginY = 0, X = 4, Y = 0, Hand = Hand.Left},
                            ],

                        }
                    },
                    {
                        "LAYOUT_b",
                        new KeyLayout
                        {
                            Filename = "foo.c",
                            CMacro = true,
                            JsonLayout = true,
                            Layout =
                            [
                                new Key { Encoder = 0, Label = "ESC", Matrix = new Matrix(0, 1), X = 0, Y = 0},
                                new Key { Label = "1", Matrix = new Matrix(0, 2), X = 1, Y = 0},
                                new Key { Label = "2", Matrix = new Matrix(0, 3), Rotation = 10, RotOriginX = 0, RotOriginY = 2, X = 0, Y = 0},
                                new Key { Label = "3", Matrix = new Matrix(0, 2), X = 0, Y = 1, Width = 1.25, Height = 2, Hand = Hand.Right},
                                new Key { Label = "4", Matrix = new Matrix(0, 3), Rotation = -10, RotOriginX = 0, RotOriginY = 3, X = 1, Y = 1, Hand = Hand.Aster},
                            ],

                        }
                    },
                },
                Haptic = new Haptic
                {
                    Driver = HapticDriver.drv2605l,
                },
                Host = new Host
                {
                    Default = new HostDefault
                    {
                        Nkro = true,
                    },
                },
                LeaderKey = new LeaderKey
                {
                    Timing = true,
                    StrictProcessing = false,
                    Timeout = 200,
                },
                MatrixPins = new MatrixPins
                {
                    Custom = true,
                    CustomLite = true,
                    Ghost = false,
                    InputPressedState = 18,
                    IODelay = 5,
                    Masked = true,
                    Direct =
                    [
                        [McuPin.C0, McuPin.C1, McuPin.C2, McuPin.C3],
                        [McuPin.C4, McuPin.C5, McuPin.C6, McuPin.C7],
                        [null, McuPin.C8, null, McuPin.C9],
                    ],
                    Cols = [McuPin.C10, McuPin.C11, McuPin.C12, McuPin.C13, McuPin.C14],
                    Rows = [McuPin.C15, McuPin.C16, McuPin.C17, McuPin.C18],
                },
                Modules = ["module1", "module2", "module3", "module4"],
                MouseKey = new MouseKey
                {
                    Enabled = true,
                    Delay = 8,
                    Interval = 12,
                    MaxSpeed = 80,
                    TimeToMax = 28,
                    WheelDelay = 18,
                },
                Oneshot = new Oneshot
                {
                    TapToggle = 3,
                    Timeout = 13,
                },
                LedMatrix = new LedMatrix
                {
                    Animations = new LedMatrixAnimations
                    {
                        None = true,
                        Solid = true,
                        AlphasMods = true,
                        Breathing = true,
                        Band = true,
                        BandPinwheel = true,
                        BandSpiral = true,
                        CycleLeftRight = true,
                        CycleUpDown = true,
                        CycleOutIn = true,
                        DualBeacon = true,
                        SolidReactiveSimple = true,
                        SolidReactive = true,
                        SolidReactiveWide = true,
                        SolidReactiveMultiwide = true,
                        SolidReactiveCross = true,
                        SolidReactiveMulticross = true,
                        SolidReactiveNexus = true,
                        SolidReactiveMultinexus = true,
                        Splash = true,
                        Multisplash = true,
                        WaveLeftRight = true,
                        WaveUpDown = true,
                        TypingHeatmap = true,
                    },
                    Default = new LedMatrixDefault
                    {
                        On = true,
                        Animation = "splash",
                        Val = 120,
                        Speed = 80,
                        Flags = (byte)LightingFlag.All,
                    },
                    Driver = LedMatrixDriver.snled27351,
                    CenterPoint = new Matrix(5, 13),
                    FlagSteps =
                    [
                        (byte)LightingFlag.None,
                        (byte)(LightingFlag.Keylight | LightingFlag.Indicator),
                        (byte)LightingFlag.Underglow
                    ],
                    MaxBrightness = 100,
                    Timeout = 10000,
                    ValSteps = 10,
                    SpeedSteps = 25,
                    LedFlushLimit = 10,
                    LedProcessLimit = 20,
                    ReactOnKeyup = true,
                    Sleep = true,
                    SplitCount = new SplitCount(5, 10),
                    Layout =
                    [
                        new Led { Matrix = new Matrix(0, 1), X = 0, Y = 0, Flags = (byte)LightingFlag.All },
                        new Led { Matrix = new Matrix(0, 2), X = 1, Y = 0, Flags = (byte)LightingFlag.Indicator },
                        new Led { Matrix = new Matrix(0, 3), X = 2, Y = 0, Flags = (byte)(LightingFlag.Keylight | LightingFlag.Modifier) },
                    ],
                },
                RgbMatrix = new RgbMatrix
                {
                    Animations = new RgbMatrixAnimations
                    {
                        None = true,
                        SolidColor = true,
                        AlphasMods = true,
                        GradientUpDown = true,
                        GradientLeftRight = true,
                        Breathing = true,
                        BandSat = true,
                        BandVal = true,
                        BandPinwheelSat = true,
                        BandPinwheelVal = true,
                        BandSpiralSat = true,
                        BandSpiralVal = true,
                        CycleAll = true,
                        CycleLeftRight = true,
                        CycleUpDown = true,
                        CycleOutIn = true,
                        CycleOutInDual = true,
                        RainbowMovingChevron = true,
                        CyclePinwheel = true,
                        CycleSpiral = true,
                        DualBeacon = true,
                        RainbowBeacon = true,
                        RainbowPinwheels = true,
                        FlowerBlooming = true,
                        Raindrops = true,
                        JellybeanRaindrops = true,
                        HueBreathing = true,
                        HuePendulum = true,
                        HueWave = true,
                        PixelFractal = true,
                        PixelFlow = true,
                        PixelRain = true,
                        TypingHeatmap = true,
                        DigitalRain = true,
                        SolidReactiveSimple = true,
                        SolidReactive = true,
                        SolidReactiveWide = true,
                        SolidReactiveMultiwide = true,
                        SolidReactiveCross = true,
                        SolidReactiveMulticross = true,
                        SolidReactiveNexus = true,
                        SolidReactiveMultinexus = true,
                        Splash = true,
                        Multisplash = true,
                        SolidSplash = true,
                        SolidMultisplash = true,
                        Starlight = true,
                        StarlightSmooth = true,
                        StarlightDualHue = true,
                        StarlightDualSat = true,
                        Riverflow = true,
                    },
                    Default = new RgbMatrixDefault
                    {
                        On = true,
                        Animation = "splash",
                        Hue = 85,
                        Sat = 128,
                        Val = 100,
                        Speed = 35,
                        Flags = (byte)LightingFlag.All,
                    },
                    Driver = RgbMatrixDriver.ws2812,
                    CenterPoint = new Matrix(10, 15),
                    FlagSteps =
                    [
                        (byte)LightingFlag.All,
                        (byte)(LightingFlag.Indicator | LightingFlag.Underglow),
                        (byte)(LightingFlag.Keylight | LightingFlag.Indicator),
                    ],
                    MaxBrightness = 100,
                    Timeout = 200,
                    HueSteps = 5,
                    SatSteps = 10,
                    ValSteps = 2,
                    SpeedSteps = 20,
                    LedFlushLimit = 100,
                    LedProcessLimit = 25,
                    ReactOnKeyup = true,
                    Sleep = true,
                    SplitCount = new SplitCount(10, 8),
                    Layout =
                    [
                        new RgbLed { Matrix = new Matrix(0, 0), X = 0, Y = 0, Flags = (byte)LightingFlag.All },
                        new RgbLed { Matrix = new Matrix(0, 1), X = 1, Y = 0, Flags = (byte)LightingFlag.Indicator },
                        new RgbLed { Matrix = new Matrix(1, 0), X = 0, Y = 0, Flags = (byte)LightingFlag.Underglow },
                        new RgbLed { Matrix = new Matrix(1, 1), X = 1, Y = 1, Flags = (byte)(LightingFlag.Keylight | LightingFlag.Modifier) },
                    ],
                },
                Rgblight = new Rgblight
                {
                    Animations = new RgblightAnimations
                    {
                        StaticLight = true,
                        Breathing = true,
                        RainbowMood = true,
                        RainbowSwirl = true,
                        Snake = true,
                        Knight = true,
                        Christmas = true,
                        StaticGradient = true,
                        RgbTest = true,
                        Alternating = true,
                        Twinkle = true,
                    },
                    BrightnessSteps = 5,
                    Default = new RgblightDefault
                    {
                        On = true,
                        Animation = "twinkle",
                        Hue = 110,
                        Sat = 88,
                        Val = 90,
                        Speed = 40,
                    },
                    Driver = RgblightDriver.ws2812,
                    HueSteps = 12,
                    Layers = new RgblightLayers
                    {
                        Blink = true,
                        Enabled = true,
                        Max = 400,
                        OverrideRgb = true,
                    },
                    LedCount = 19,
                    LedMap = [0, 1, 2, 3],
                    MaxBrightness = 127,
                    SaturationSteps = 8,
                    Sleep = true,
                    Split = true,
                    SplitCount = new SplitCount(7, 12),
                },
                Secure = new Secure
                {
                    Enabled = true,
                    UnlockTimeout = 360000,
                    IdleTimeout = 60000,
                    UnlockSequence =
                    [
                        new Matrix(0, 1),
                        new Matrix(2, 2),
                        new Matrix(1, 3),
                        new Matrix(4, 4),
                    ],
                },
                Stenography = new Stenography
                {
                    Enabled = true,
                    CombinedMap = true,
                    Default = new StenographyDefault
                    {
                        Mode = StenographyMode.txbolt,
                    },
                    Protocol = StenographyProtocol.txbolt,
                },
                Ps2 = new Ps2
                {
                    Enabled = true,
                    MouseEnabled = true,
                    ClockPin = McuPin.GP0,
                    DataPin = McuPin.GP1,
                    Driver = Ps2Driver.interrupt,
                },
                Split = new Split
                {
                    Enabled = true,
                    Bootmagic = new SplitBootmagic
                    {
                        Matrix = new Matrix(0, 0),
                    },
                    MatrixPins = new SplitRightPins
                    {
                        Right = new SplitMatrixPins
                        {
                            Direct =
                            [
                                [McuPin.LINE_PIN0, McuPin.LINE_PIN1, McuPin.LINE_PIN2, McuPin.LINE_PIN3],
                                [McuPin.LINE_PIN4, McuPin.LINE_PIN5, McuPin.LINE_PIN6, McuPin.LINE_PIN7],
                                [McuPin.LINE_PIN8, null, null, McuPin.LINE_PIN9],
                            ],
                            Cols = [McuPin.LINE_PIN10, McuPin.LINE_PIN11, McuPin.LINE_PIN12, McuPin.LINE_PIN13, McuPin.LINE_PIN14],
                            Rows = [McuPin.LINE_PIN15, McuPin.LINE_PIN16, McuPin.LINE_PIN17],
                            Unused = [McuPin.LINE_PIN18, McuPin.LINE_PIN19, McuPin.LINE_PIN20],
                        },
                    },
                    DipSwitch = new SplitRightDipSwitch
                    {
                        Right = new DipSwitchConfig
                        {
                            Pins = [McuPin.E0, McuPin.E1, McuPin.E2, McuPin.E3],
                        },
                    },
                    Encoder = new SplitRightEncoder
                    {
                        Right = new EncoderConfig
                        {
                            Driver = EncoderDriver.quadrature,
                            Rotary =
                            [
                                new Rotary
                                {
                                    PinA = McuPin.F0,
                                    PinB = McuPin.F1,
                                    Resolution = 4,
                                },
                                new Rotary
                                {
                                    PinA = McuPin.F2,
                                    PinB = McuPin.F3,
                                    Resolution = 8,
                                },
                                new Rotary
                                {
                                    PinA = McuPin.F4,
                                    PinB = McuPin.F5,
                                },
                            ],
                        },
                    },
                    Handedness = new SplitHandedness
                    {
                        Pin = McuPin.F6,
                        MatrixGrid = [McuPin.F7, McuPin.F8]
                    },
                    Serial = new SplitSerial
                    {
                        Driver = SplitSerialDriver.bitbang,
                        Pin = McuPin.F9,
                        Speed = 5,
                    },
                    Transport = new SplitTransport
                    {
                        Protocol = SplitTransportProtocol.serial,
                        Sync = new SplitTransportSync
                        {
                            Activity = true,
                            DetectedOS = true,
                            Haptic = true,
                            LayerState = true,
                            Indicators = true,
                            MatrixState = true,
                            Modifiers = true,
                            Oled = true,
                            ST7565 = true,
                            WPM = true,
                        },
                        Watchdog = true,
                        WatchdogTimeout = 10000,
                    },
                    UsbDetect = new SplitUsbDetect
                    {
                        Enabled = true,
                        PollingInterval = 200,
                        Timeout = 500,
                    },
                },
                Tags = ["tag1", "tag2", "tag3", "tag4"],
                Tapping = new Tapping
                {
                    ChordalHold = true,
                    FlowTapTerm = 50,
                    ForceHold = true,
                    ForceHoldPerKey = true,
                    IgnoreModTapInterrupt = true,
                    HoldOnOtherKeyPress = true,
                    HoldOnOtherKeyPressPerKey = true,
                    PermissiveHold = true,
                    PermissiveHoldPerKey = true,
                    Retro = false,
                    RetroPerKey = false,
                    SpeculativeHold = true,
                    SpeculativeHoldFlowTerm = 120,
                    SpeculativeHoldOneKey = true,
                    Term = 200,
                    TermPerKey = true,
                    Toggle = 35,
                },
                Usb = new Usb
                {
                    DeviceVersion = new(0, 1, 2),
                    Pid = 0x1234,
                    Vid = 0xABCD,
                    MaxPower = 99999,
                    NoStartupCheck = true,
                    PollingInterval = 30,
                    SharedEndpoint = new UsbSharedEndpoint
                    {
                        Keyboard = true,
                        Mouse = true,
                    },
                    SuspendWakeupDelay = 10,
                    WaitForEnumeration = false,
                },
                Qmk = new Qmk
                {
                    KeysPerScan = 10,
                    TapKeycodeDelay = 20,
                    TapCapslockDelay = 100,
                    Locking = new QmkLocking
                    {
                        Enabled = true,
                        Resync = true,
                    },
                },
                QmkLufaBootloader = new QmkLufaBootloader
                {
                    EscOutput = McuPin.G0,
                    EscInput = McuPin.G1,
                    Led = McuPin.G2,
                    Speaker = McuPin.G3,
                },
                WS2812 = new WS2812
                {
                    Driver = WS2812Driver.pwm,
                    Pin = McuPin.H0,
                    Rgbw = true,
                    I2cAddress = 0x83,
                    I2cTimeout = 300,
                },
            };

            var json = QmkJsonSerializer.Serialize(kbd);

            json.Should().Be(ExpectedData.ReadAllDefinedJson());
        }
    }
}
