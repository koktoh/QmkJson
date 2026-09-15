using AwesomeAssertions;
using QmkJson.Definitions;

namespace QmkJson.Test
{
    public class DeserializeTest
    {
        [Fact]
        public void ShouldBeDeserializeWithoutError()
        {
            foreach (var file in QmkJsonEnumerator.Enumerate())
            {
                if (InvalidJsons.Contains(file)) continue;

                var relativePath = Path.GetRelativePath(QmkPath.GetQmkKeyboardsRoot(), file);

                var json = File.ReadAllText(file);

                try
                {
                    var kbd = QmkJsonSerializer.Deserialize(json);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Faild serialize of {relativePath}", ex);
                }
            }
        }

        [Fact]
        public void DeserializeUnionKeyboardTest()
        {
            var file = Path.Combine(QmkPath.GetQmkKeyboardsRoot(), @"clueboard\66\rev4\keyboard.json");

            var json = File.ReadAllText(file);

            var kbd = QmkJsonSerializer.Deserialize(json);

            var expectedKbd = new Keyboard
            {
                Manufacturer = "Clueboard",
                KeyboardName = "Clueboard 66% rev4",
                Maintainer = "skullydazed",
                Processor = Processor.STM32F303,
                Board = "QMK_PROTON_C",
                Bootloader = Bootloader.stm32_dfu,
                DiodeDirection = DiodeDirection.COL2ROW,
            };

            // features
            expectedKbd.Features = new Features
            {
                Audio = true,
                Bootmagic = false,
                Console = true,
                Extrakey = true,
                Mousekey = true,
                Nkro = true,
            };

            // matrix_pins
            expectedKbd.MatrixPins = new MatrixPins
            {
                Cols = [McuPin.B10, McuPin.B2, McuPin.B1, McuPin.B0, McuPin.A7, McuPin.B4, McuPin.B3, McuPin.B5],
                Rows = [McuPin.B11, McuPin.A6, McuPin.A3, McuPin.A2, McuPin.A1, McuPin.B7, McuPin.B6, McuPin.C15, McuPin.C14, McuPin.C13],
            };

            // rgblight
            var rgblightAnimations = new RgblightAnimations
            {
                Alternating = true,
                Breathing = true,
                Christmas = true,
                Knight = true,
                RainbowMood = true,
                RainbowSwirl = true,
                RgbTest = true,
                Snake = true,
                StaticGradient = true,
                Twinkle = true,
            };

            expectedKbd.Rgblight = new Rgblight
            {
                Animations = rgblightAnimations,
                HueSteps = 32,
                LedCount = 18,
            };

            // ws2812
            expectedKbd.WS2812 = new WS2812
            {
                Pin = McuPin.D7,
            };

            // usb
            expectedKbd.Usb = new Usb
            {
                DeviceVersion = new(0, 0, 1),
                Pid = 0x2390,
                Vid = 0xC1ED,
            };

            // community_layouts
            expectedKbd.CommunityLayouts = ["66_ansi", "66_iso"];

            // layout_aliases
            expectedKbd.LayoutAliases = new Dictionary<string, string>
            {
                { "LAYOUT", "LAYOUT_all" },
            };

            // layouts
            var layout66AnsiName = "LAYOUT_66_ansi";
            var layout66Ansi = new[]
            {
                new Key { Label = "~", Matrix = new Matrix(0, 0), X = 0, Y = 0 },
                new Key { Label = "!", Matrix = new Matrix(0, 1), X = 1, Y = 0 },
                new Key { Label = "@", Matrix = new Matrix(0, 2), X = 2, Y = 0 },
                new Key { Label = "#", Matrix = new Matrix(0, 3), X = 3, Y = 0 },
                new Key { Label = "$", Matrix = new Matrix(0, 4), X = 4, Y = 0 },
                new Key { Label = "%", Matrix = new Matrix(0, 5), X = 5, Y = 0 },
                new Key { Label = "^", Matrix = new Matrix(0, 6), X = 6, Y = 0 },
                new Key { Label = "&", Matrix = new Matrix(0, 7), X = 7, Y = 0 },
                new Key { Label = "*", Matrix = new Matrix(5, 0), X = 8, Y = 0 },
                new Key { Label = "(", Matrix = new Matrix(5, 1), X = 9, Y = 0 },
                new Key { Label = ")", Matrix = new Matrix(5, 2), X = 10, Y = 0 },
                new Key { Label = "_", Matrix = new Matrix(5, 3), X = 11, Y = 0 },
                new Key { Label = "+", Matrix = new Matrix(5, 4), X = 12, Y = 0 },
                new Key { Label = "Backspace", Matrix = new Matrix(5, 6), Width = 2, X = 13, Y = 0 },
                new Key { Label = "Page Up", Matrix = new Matrix(5, 7), X = 15.5, Y = 0 },
                new Key { Label = "Tab", Matrix = new Matrix(1, 0), Width = 1.5, X = 0, Y = 1 },
                new Key { Label = "Q", Matrix = new Matrix(1, 1), X = 1.5, Y = 1 },
                new Key { Label = "W", Matrix = new Matrix(1, 2), X = 2.5, Y = 1 },
                new Key { Label = "E", Matrix = new Matrix(1, 3), X = 3.5, Y = 1 },
                new Key { Label = "R", Matrix = new Matrix(1, 4), X = 4.5, Y = 1 },
                new Key { Label = "T", Matrix = new Matrix(1, 5), X = 5.5, Y = 1 },
                new Key { Label = "Y", Matrix = new Matrix(1, 6), X = 6.5, Y = 1 },
                new Key { Label = "U", Matrix = new Matrix(1, 7), X = 7.5, Y = 1 },
                new Key { Label = "I", Matrix = new Matrix(6, 0), X = 8.5, Y = 1 },
                new Key { Label = "O", Matrix = new Matrix(6, 1), X = 9.5, Y = 1 },
                new Key { Label = "P", Matrix = new Matrix(6, 2), X = 10.5, Y = 1 },
                new Key { Label = "{", Matrix = new Matrix(6, 3), X = 11.5, Y = 1 },
                new Key { Label = "}", Matrix = new Matrix(6, 4), X = 12.5, Y = 1 },
                new Key { Label = "|", Matrix = new Matrix(6, 5), Width = 1.5, X = 13.5, Y = 1 },
                new Key { Label = "Page Down", Matrix = new Matrix(6, 7), X = 15.5, Y = 1 },
                new Key { Label = "Caps Lock", Matrix = new Matrix(2, 0), Width = 1.75, X = 0, Y = 2 },
                new Key { Label = "A", Matrix = new Matrix(2, 1), X = 1.75, Y = 2 },
                new Key { Label = "S", Matrix = new Matrix(2, 2), X = 2.75, Y = 2 },
                new Key { Label = "D", Matrix = new Matrix(2, 3), X = 3.75, Y = 2 },
                new Key { Label = "F", Matrix = new Matrix(2, 4), X = 4.75, Y = 2 },
                new Key { Label = "G", Matrix = new Matrix(2, 5), X = 5.75, Y = 2 },
                new Key { Label = "H", Matrix = new Matrix(2, 6), X = 6.75, Y = 2 },
                new Key { Label = "J", Matrix = new Matrix(2, 7), X = 7.75, Y = 2 },
                new Key { Label = "K", Matrix = new Matrix(7, 0), X = 8.75, Y = 2 },
                new Key { Label = "L", Matrix = new Matrix(7, 1), X = 9.75, Y = 2 },
                new Key { Label = ":", Matrix = new Matrix(7, 2), X = 10.75, Y = 2 },
                new Key { Label = "\"", Matrix = new Matrix(7, 3), X = 11.75, Y = 2 },
                new Key { Label = "Enter", Matrix = new Matrix(7, 5), Width = 2.25, X = 12.75, Y = 2 },
                new Key { Label = "Shift", Matrix = new Matrix(3, 0), Width = 2.25, X = 0, Y = 3 },
                new Key { Label = "Z", Matrix = new Matrix(3, 2), X = 2.25, Y = 3 },
                new Key { Label = "X", Matrix = new Matrix(3, 3), X = 3.25, Y = 3 },
                new Key { Label = "C", Matrix = new Matrix(3, 4), X = 4.25, Y = 3 },
                new Key { Label = "V", Matrix = new Matrix(3, 5), X = 5.25, Y = 3 },
                new Key { Label = "B", Matrix = new Matrix(3, 6), X = 6.25, Y = 3 },
                new Key { Label = "N", Matrix = new Matrix(3, 7), X = 7.25, Y = 3 },
                new Key { Label = "M", Matrix = new Matrix(8, 0), X = 8.25, Y = 3 },
                new Key { Label = "<", Matrix = new Matrix(8, 1), X = 9.25, Y = 3 },
                new Key { Label = ">", Matrix = new Matrix(8, 2), X = 10.25, Y = 3 },
                new Key { Label = "?", Matrix = new Matrix(8, 3), X = 11.25, Y = 3 },
                new Key { Label = "Shift", Matrix = new Matrix(8, 5), Width = 2.25, X = 12.25, Y = 3 },
                new Key { Label = "Up", Matrix = new Matrix(8, 6), X = 14.5, Y = 3 },
                new Key { Label = "Ctrl", Matrix = new Matrix(4, 0), Width = 1.25, X = 0, Y = 4 },
                new Key { Label = "Win", Matrix = new Matrix(4, 1), Width = 1.25, X = 1.25, Y = 4 },
                new Key { Label = "Alt", Matrix = new Matrix(4, 2), Width = 1.25, X = 2.5, Y = 4 },
                new Key { Label = "Space", Matrix = new Matrix(4, 6), Width = 6, X = 3.75, Y = 4 },
                new Key { Label = "Alt", Matrix = new Matrix(9, 2), Width = 1.25, X = 9.75, Y = 4 },
                new Key { Label = "Win", Matrix = new Matrix(9, 3), Width = 1.25, X = 11, Y = 4 },
                new Key { Label = "Menu", Matrix = new Matrix(9, 4), Width = 1.25, X = 12.25, Y = 4 },
                new Key { Label = "Left", Matrix = new Matrix(9, 5), X = 13.5, Y = 4 },
                new Key { Label = "Down", Matrix = new Matrix(9, 6), X = 14.5, Y = 4 },
                new Key { Label = "Up", Matrix = new Matrix(9, 7), X = 15.5, Y = 4 },
            };

            var layout66IsoName = "LAYOUT_66_iso";
            var layout66Iso = new[]
            {
                new Key { Label = "~", Matrix = new Matrix(0, 0), X = 0, Y = 0 },
                new Key { Label = "!", Matrix = new Matrix(0, 1), X = 1, Y = 0 },
                new Key { Label = "@", Matrix = new Matrix(0, 2), X = 2, Y = 0 },
                new Key { Label = "#", Matrix = new Matrix(0, 3), X = 3, Y = 0 },
                new Key { Label = "$", Matrix = new Matrix(0, 4), X = 4, Y = 0 },
                new Key { Label = "%", Matrix = new Matrix(0, 5), X = 5, Y = 0 },
                new Key { Label = "^", Matrix = new Matrix(0, 6), X = 6, Y = 0 },
                new Key { Label = "&", Matrix = new Matrix(0, 7), X = 7, Y = 0 },
                new Key { Label = "*", Matrix = new Matrix(5, 0), X = 8, Y = 0 },
                new Key { Label = "(", Matrix = new Matrix(5, 1), X = 9, Y = 0 },
                new Key { Label = ")", Matrix = new Matrix(5, 2), X = 10, Y = 0 },
                new Key { Label = "_", Matrix = new Matrix(5, 3), X = 11, Y = 0 },
                new Key { Label = "+", Matrix = new Matrix(5, 4), X = 12, Y = 0 },
                new Key { Label = "Backspace", Matrix = new Matrix(5, 6), Width = 2, X = 13, Y = 0 },
                new Key { Label = "Insert", Matrix = new Matrix(5, 7), X = 15.5, Y = 0 },
                new Key { Label = "Tab", Matrix = new Matrix(1, 0), Width = 1.5, X = 0, Y = 1 },
                new Key { Label = "Q", Matrix = new Matrix(1, 1), X = 1.5, Y = 1 },
                new Key { Label = "W", Matrix = new Matrix(1, 2), X = 2.5, Y = 1 },
                new Key { Label = "E", Matrix = new Matrix(1, 3), X = 3.5, Y = 1 },
                new Key { Label = "R", Matrix = new Matrix(1, 4), X = 4.5, Y = 1 },
                new Key { Label = "T", Matrix = new Matrix(1, 5), X = 5.5, Y = 1 },
                new Key { Label = "Y", Matrix = new Matrix(1, 6), X = 6.5, Y = 1 },
                new Key { Label = "U", Matrix = new Matrix(1, 7), X = 7.5, Y = 1 },
                new Key { Label = "I", Matrix = new Matrix(6, 0), X = 8.5, Y = 1 },
                new Key { Label = "O", Matrix = new Matrix(6, 1), X = 9.5, Y = 1 },
                new Key { Label = "P", Matrix = new Matrix(6, 2), X = 10.5, Y = 1 },
                new Key { Label = "{", Matrix = new Matrix(6, 3), X = 11.5, Y = 1 },
                new Key { Label = "}", Matrix = new Matrix(6, 4), X = 12.5, Y = 1 },
                new Key { Label = "Delete", Matrix = new Matrix(6, 7), X = 15.5, Y = 1 },
                new Key { Label = "Caps Lock", Matrix = new Matrix(2, 0), Width = 1.75, X = 0, Y = 2 },
                new Key { Label = "A", Matrix = new Matrix(2, 1), X = 1.75, Y = 2 },
                new Key { Label = "S", Matrix = new Matrix(2, 2), X = 2.75, Y = 2 },
                new Key { Label = "D", Matrix = new Matrix(2, 3), X = 3.75, Y = 2 },
                new Key { Label = "F", Matrix = new Matrix(2, 4), X = 4.75, Y = 2 },
                new Key { Label = "G", Matrix = new Matrix(2, 5), X = 5.75, Y = 2 },
                new Key { Label = "H", Matrix = new Matrix(2, 6), X = 6.75, Y = 2 },
                new Key { Label = "J", Matrix = new Matrix(2, 7), X = 7.75, Y = 2 },
                new Key { Label = "K", Matrix = new Matrix(7, 0), X = 8.75, Y = 2 },
                new Key { Label = "L", Matrix = new Matrix(7, 1), X = 9.75, Y = 2 },
                new Key { Label = ":", Matrix = new Matrix(7, 2), X = 10.75, Y = 2 },
                new Key { Label = "\"", Matrix = new Matrix(7, 3), X = 11.75, Y = 2 },
                new Key { Label = "", Matrix = new Matrix(7, 4), X = 12.75, Y = 2 },
                new Key { Label = "Enter", Matrix = new Matrix(7, 5), Width = 1.25, Height = 2, X = 13.75, Y = 1 },
                new Key { Label = "Shift", Matrix = new Matrix(3, 0), Width = 1.25, X = 0, Y = 3 },
                new Key { Label = "\\", Matrix = new Matrix(3, 1), X = 1.25, Y = 3 },
                new Key { Label = "Z", Matrix = new Matrix(3, 2), X = 2.25, Y = 3 },
                new Key { Label = "X", Matrix = new Matrix(3, 3), X = 3.25, Y = 3 },
                new Key { Label = "C", Matrix = new Matrix(3, 4), X = 4.25, Y = 3 },
                new Key { Label = "V", Matrix = new Matrix(3, 5), X = 5.25, Y = 3 },
                new Key { Label = "B", Matrix = new Matrix(3, 6), X = 6.25, Y = 3 },
                new Key { Label = "N", Matrix = new Matrix(3, 7), X = 7.25, Y = 3 },
                new Key { Label = "M", Matrix = new Matrix(8, 0), X = 8.25, Y = 3 },
                new Key { Label = "<", Matrix = new Matrix(8, 1), X = 9.25, Y = 3 },
                new Key { Label = ">", Matrix = new Matrix(8, 2), X = 10.25, Y = 3 },
                new Key { Label = "?", Matrix = new Matrix(8, 3), X = 11.25, Y = 3 },
                new Key { Label = "Shift", Matrix = new Matrix(8, 5), Width = 2.25, X = 12.25, Y = 3 },
                new Key { Label = "↑", Matrix = new Matrix(8, 6), X = 14.5, Y = 3 },
                new Key { Label = "Ctrl", Matrix = new Matrix(4, 0), Width = 1.25, X = 0, Y = 4 },
                new Key { Label = "Win", Matrix = new Matrix(4, 1), Width = 1.25, X = 1.25, Y = 4 },
                new Key { Label = "Alt", Matrix = new Matrix(4, 2), Width = 1.25, X = 2.5, Y = 4 },
                new Key { Label = "Space", Matrix = new Matrix(4, 6), Width = 6, X = 3.75, Y = 4 },
                new Key { Label = "Alt", Matrix = new Matrix(9, 2), Width = 1.25, X = 9.75, Y = 4 },
                new Key { Label = "Ctrl", Matrix = new Matrix(9, 3), Width = 1.25, X = 11, Y = 4 },
                new Key { Label = "Menu", Matrix = new Matrix(9, 4), Width = 1.25, X = 12.25, Y = 4 },
                new Key { Label = "←", Matrix = new Matrix(9, 5), X = 13.5, Y = 4 },
                new Key { Label = "↓", Matrix = new Matrix(9, 6), X = 14.5, Y = 4 },
                new Key { Label = "→", Matrix = new Matrix(9, 7), X = 15.5, Y = 4 },
            };

            var layoutAllName = "LAYOUT_all";
            var layoutAll = new[]
            {
                new Key { Label = "GRAVE", Matrix = new Matrix(0, 0), X = 0, Y = 0 },
                new Key { Label = "1", Matrix = new Matrix(0, 1), X = 1, Y = 0 },
                new Key { Label = "2", Matrix = new Matrix(0, 2), X = 2, Y = 0 },
                new Key { Label = "3", Matrix = new Matrix(0, 3), X = 3, Y = 0 },
                new Key { Label = "4", Matrix = new Matrix(0, 4), X = 4, Y = 0 },
                new Key { Label = "5", Matrix = new Matrix(0, 5), X = 5, Y = 0 },
                new Key { Label = "6", Matrix = new Matrix(0, 6), X = 6, Y = 0 },
                new Key { Label = "7", Matrix = new Matrix(0, 7), X = 7, Y = 0 },
                new Key { Label = "8", Matrix = new Matrix(5, 0), X = 8, Y = 0 },
                new Key { Label = "9", Matrix = new Matrix(5, 1), X = 9, Y = 0 },
                new Key { Label = "0", Matrix = new Matrix(5, 2), X = 10, Y = 0 },
                new Key { Label = "DASH", Matrix = new Matrix(5, 3), X = 11, Y = 0 },
                new Key { Label = "EQUALSIGN", Matrix = new Matrix(5, 4), X = 12, Y = 0 },
                new Key { Label = "YEN", Matrix = new Matrix(5, 5), X = 13, Y = 0 },
                new Key { Label = "BACKSPACE", Matrix = new Matrix(5, 6), X = 14, Y = 0 },
                new Key { Label = "PAGEUP", Matrix = new Matrix(5, 7), X = 15.5, Y = 0 },
                new Key { Label = "TAB", Matrix = new Matrix(1, 0), Width = 1.5, X = 0, Y = 1 },
                new Key { Label = "Q", Matrix = new Matrix(1, 1), X = 1.5, Y = 1 },
                new Key { Label = "W", Matrix = new Matrix(1, 2), X = 2.5, Y = 1 },
                new Key { Label = "E", Matrix = new Matrix(1, 3), X = 3.5, Y = 1 },
                new Key { Label = "R", Matrix = new Matrix(1, 4), X = 4.5, Y = 1 },
                new Key { Label = "T", Matrix = new Matrix(1, 5), X = 5.5, Y = 1 },
                new Key { Label = "Y", Matrix = new Matrix(1, 6), X = 6.5, Y = 1 },
                new Key { Label = "U", Matrix = new Matrix(1, 7), X = 7.5, Y = 1 },
                new Key { Label = "I", Matrix = new Matrix(6, 0), X = 8.5, Y = 1 },
                new Key { Label = "O", Matrix = new Matrix(6, 1), X = 9.5, Y = 1 },
                new Key { Label = "P", Matrix = new Matrix(6, 2), X = 10.5, Y = 1 },
                new Key { Label = "LBRACKET", Matrix = new Matrix(6, 3), X = 11.5, Y = 1 },
                new Key { Label = "RBRACKET", Matrix = new Matrix(6, 4), X = 12.5, Y = 1 },
                new Key { Label = "BACKSLASH", Matrix = new Matrix(6, 5), Width = 1.5, X = 13.5, Y = 1 },
                new Key { Label = "PAGEDOWN", Matrix = new Matrix(6, 7), X = 15.5, Y = 1 },
                new Key { Label = "CAPSLOCK", Matrix = new Matrix(2, 0), Width = 1.75, X = 0, Y = 2 },
                new Key { Label = "A", Matrix = new Matrix(2, 1), X = 1.75, Y = 2 },
                new Key { Label = "S", Matrix = new Matrix(2, 2), X = 2.75, Y = 2 },
                new Key { Label = "D", Matrix = new Matrix(2, 3), X = 3.75, Y = 2 },
                new Key { Label = "F", Matrix = new Matrix(2, 4), X = 4.75, Y = 2 },
                new Key { Label = "G", Matrix = new Matrix(2, 5), X = 5.75, Y = 2 },
                new Key { Label = "H", Matrix = new Matrix(2, 6), X = 6.75, Y = 2 },
                new Key { Label = "J", Matrix = new Matrix(2, 7), X = 7.75, Y = 2 },
                new Key { Label = "K", Matrix = new Matrix(7, 0), X = 8.75, Y = 2 },
                new Key { Label = "L", Matrix = new Matrix(7, 1), X = 9.75, Y = 2 },
                new Key { Label = "SEMICOLON", Matrix = new Matrix(7, 2), X = 10.75, Y = 2 },
                new Key { Label = "QUOTE", Matrix = new Matrix(7, 3), X = 11.75, Y = 2 },
                new Key { Label = "ISOHASH", Matrix = new Matrix(7, 4), X = 12.75, Y = 2 },
                new Key { Label = "ENTER", Matrix = new Matrix(7, 5), Width = 1.25, X = 13.75, Y = 2 },
                new Key { Label = "LSHIFT", Matrix = new Matrix(3, 0), Width = 1.25, X = 0, Y = 3 },
                new Key { Label = "ISOBACKSLASH", Matrix = new Matrix(3, 1), X = 1.25, Y = 3 },
                new Key { Label = "Z", Matrix = new Matrix(3, 2), X = 2.25, Y = 3 },
                new Key { Label = "X", Matrix = new Matrix(3, 3), X = 3.25, Y = 3 },
                new Key { Label = "C", Matrix = new Matrix(3, 4), X = 4.25, Y = 3 },
                new Key { Label = "V", Matrix = new Matrix(3, 5), X = 5.25, Y = 3 },
                new Key { Label = "B", Matrix = new Matrix(3, 6), X = 6.25, Y = 3 },
                new Key { Label = "N", Matrix = new Matrix(3, 7), X = 7.25, Y = 3 },
                new Key { Label = "M", Matrix = new Matrix(8, 0), X = 8.25, Y = 3 },
                new Key { Label = "COMMA", Matrix = new Matrix(8, 1), X = 9.25, Y = 3 },
                new Key { Label = "PERIOD", Matrix = new Matrix(8, 2), X = 10.25, Y = 3 },
                new Key { Label = "SLASH", Matrix = new Matrix(8, 3), X = 11.25, Y = 3 },
                new Key { Label = "JPBACKSLASH", Matrix = new Matrix(8, 4), X = 12.25, Y = 3 },
                new Key { Label = "RSHIFT", Matrix = new Matrix(8, 5), Width = 1.25, X = 13.25, Y = 3 },
                new Key { Label = "UP", Matrix = new Matrix(8, 6), X = 14.5, Y = 3 },
                new Key { Label = "LCTRL", Matrix = new Matrix(4, 0), Width = 1.25, X = 0, Y = 4 },
                new Key { Label = "LALT", Matrix = new Matrix(4, 1), X = 1.25, Y = 4 },
                new Key { Label = "LCMD", Matrix = new Matrix(4, 2), Width = 1.25, X = 2.25, Y = 4 },
                new Key { Label = "MUHENKAN", Matrix = new Matrix(4, 3), Width = 1.25, X = 3.5, Y = 4 },
                new Key { Label = "SPACE1", Matrix = new Matrix(4, 5), Width = 2, X = 4.75, Y = 4 },
                new Key { Label = "SPACE2", Matrix = new Matrix(4, 6), Width = 2, X = 6.75, Y = 4 },
                new Key { Label = "HENKAN", Matrix = new Matrix(9, 0), Width = 1.25, X = 8.75, Y = 4 },
                new Key { Label = "RCMD", Matrix = new Matrix(9, 2), Width = 1.25, X = 10, Y = 4 },
                new Key { Label = "RCTRL", Matrix = new Matrix(9, 3), X = 11.25, Y = 4 },
                new Key { Label = "FN", Matrix = new Matrix(9, 4), Width = 1.25, X = 12.25, Y = 4 },
                new Key { Label = "LEFT", Matrix = new Matrix(9, 5), X = 13.5, Y = 4 },
                new Key { Label = "DOWN", Matrix = new Matrix(9, 6), X = 14.5, Y = 4 },
                new Key { Label = "RIGHT", Matrix = new Matrix(9, 7), X = 15.5, Y = 4 },
            };

            expectedKbd.Layouts = new Dictionary<string, KeyLayout>
            {
                { layout66AnsiName, new KeyLayout { Layout = layout66Ansi } },
                { layout66IsoName, new KeyLayout { Layout = layout66Iso } },
                { layoutAllName, new KeyLayout { Layout = layoutAll } },
            };

            kbd.Should().BeEquivalentTo(expectedKbd);
        }

        [Fact]
        public void DeserializeSplitKeyboardTest1()
        {
            var file = Path.Combine(QmkPath.GetQmkKeyboardsRoot(), @"crkbd\info.json");

            var json = File.ReadAllText(file);

            var kbd = QmkJsonSerializer.Deserialize(json);

            var expectedKbd = new Keyboard
            {
                Manufacturer = "foostan",
                Url = "https://github.com/foostan/crkbd",
                Maintainer = "qmk",
                Usb = new Usb { Vid = 0x4653 },
            };

            // features
            expectedKbd.Features = new Features
            {
                Bootmagic = true,
                Extrakey = true,
                Nkro = true,
                Oled = true,
                Rgblight = false,
                RgbMatrix = true,
            };

            // bootmagic
            expectedKbd.Bootmagic = new Bootmagic
            {
                Matrix = new Matrix(0, 1),
            };

            // split
            expectedKbd.Split = new Split
            {
                Enabled = true,
                Bootmagic = new SplitBootmagic { Matrix = new Matrix(4, 1) },
            };

            // layout_aliases
            expectedKbd.LayoutAliases = new Dictionary<string, string>
            {
                { "LAYOUT", "LAYOUT_split_3x6_3" },
            };

            // community_layouts
            expectedKbd.CommunityLayouts = ["split_3x5_3", "split_3x6_3"];

            // layouts
            var layoutSplit3x5_3Name = "LAYOUT_split_3x5_3";
            var layoutSplit3x5_3 = new[]
            {
                new Key { Matrix = new Matrix(0, 1), X = 0, Y = 0.3 },
                new Key { Matrix = new Matrix(0, 2), X = 1, Y = 0.1 },
                new Key { Matrix = new Matrix(0, 3), X = 2, Y = 0 },
                new Key { Matrix = new Matrix(0, 4), X = 3, Y = 0.1 },
                new Key { Matrix = new Matrix(0, 5), X = 4, Y = 0.2 },
                new Key { Matrix = new Matrix(4, 5), X = 8, Y = 0.2 },
                new Key { Matrix = new Matrix(4, 4), X = 9, Y = 0.1 },
                new Key { Matrix = new Matrix(4, 3), X = 10, Y = 0 },
                new Key { Matrix = new Matrix(4, 2), X = 11, Y = 0.1 },
                new Key { Matrix = new Matrix(4, 1), X = 12, Y = 0.3 },
                new Key { Matrix = new Matrix(1, 1), X = 0, Y = 1.3 },
                new Key { Matrix = new Matrix(1, 2), X = 1, Y = 1.1 },
                new Key { Matrix = new Matrix(1, 3), X = 2, Y = 1 },
                new Key { Matrix = new Matrix(1, 4), X = 3, Y = 1.1 },
                new Key { Matrix = new Matrix(1, 5), X = 4, Y = 1.2 },
                new Key { Matrix = new Matrix(5, 5), X = 8, Y = 1.2 },
                new Key { Matrix = new Matrix(5, 4), X = 9, Y = 1.1 },
                new Key { Matrix = new Matrix(5, 3), X = 10, Y = 1 },
                new Key { Matrix = new Matrix(5, 2), X = 11, Y = 1.1 },
                new Key { Matrix = new Matrix(5, 1), X = 12, Y = 1.3 },
                new Key { Matrix = new Matrix(2, 1), X = 0, Y = 2.3 },
                new Key { Matrix = new Matrix(2, 2), X = 1, Y = 2.1 },
                new Key { Matrix = new Matrix(2, 3), X = 2, Y = 2 },
                new Key { Matrix = new Matrix(2, 4), X = 3, Y = 2.1 },
                new Key { Matrix = new Matrix(2, 5), X = 4, Y = 2.2 },
                new Key { Matrix = new Matrix(6, 5), X = 8, Y = 2.2 },
                new Key { Matrix = new Matrix(6, 4), X = 9, Y = 2.1 },
                new Key { Matrix = new Matrix(6, 3), X = 10, Y = 2 },
                new Key { Matrix = new Matrix(6, 2), X = 11, Y = 2.1 },
                new Key { Matrix = new Matrix(6, 1), X = 12, Y = 2.3 },
                new Key { Matrix = new Matrix(3, 3), X = 3, Y = 3.7 },
                new Key { Matrix = new Matrix(3, 4), X = 4, Y = 3.7 },
                new Key { Matrix = new Matrix(3, 5), Height = 1.5, X = 5, Y = 3.2 },
                new Key { Matrix = new Matrix(7, 5), Height = 1.5, X = 7, Y = 3.2 },
                new Key { Matrix = new Matrix(7, 4), X = 8, Y = 3.7 },
                new Key { Matrix = new Matrix(7, 3), X = 9, Y = 3.7 },
            };

            var layoutSplit3x6_3Name = "LAYOUT_split_3x6_3";
            var layoutSplit3x6_3 = new[]
            {
                new Key { Matrix = new Matrix(0, 0), X = 0, Y = 0.3 },
                new Key { Matrix = new Matrix(0, 1), X = 1, Y = 0.3 },
                new Key { Matrix = new Matrix(0, 2), X = 2, Y = 0.1 },
                new Key { Matrix = new Matrix(0, 3), X = 3, Y = 0 },
                new Key { Matrix = new Matrix(0, 4), X = 4, Y = 0.1 },
                new Key { Matrix = new Matrix(0, 5), X = 5, Y = 0.2 },
                new Key { Matrix = new Matrix(4, 5), X = 9, Y = 0.2 },
                new Key { Matrix = new Matrix(4, 4), X = 10, Y = 0.1 },
                new Key { Matrix = new Matrix(4, 3), X = 11, Y = 0 },
                new Key { Matrix = new Matrix(4, 2), X = 12, Y = 0.1 },
                new Key { Matrix = new Matrix(4, 1), X = 13, Y = 0.3 },
                new Key { Matrix = new Matrix(4, 0), X = 14, Y = 0.3 },
                new Key { Matrix = new Matrix(1, 0), X = 0, Y = 1.3 },
                new Key { Matrix = new Matrix(1, 1), X = 1, Y = 1.3 },
                new Key { Matrix = new Matrix(1, 2), X = 2, Y = 1.1 },
                new Key { Matrix = new Matrix(1, 3), X = 3, Y = 1 },
                new Key { Matrix = new Matrix(1, 4), X = 4, Y = 1.1 },
                new Key { Matrix = new Matrix(1, 5), X = 5, Y = 1.2 },
                new Key { Matrix = new Matrix(5, 5), X = 9, Y = 1.2 },
                new Key { Matrix = new Matrix(5, 4), X = 10, Y = 1.1 },
                new Key { Matrix = new Matrix(5, 3), X = 11, Y = 1 },
                new Key { Matrix = new Matrix(5, 2), X = 12, Y = 1.1 },
                new Key { Matrix = new Matrix(5, 1), X = 13, Y = 1.3 },
                new Key { Matrix = new Matrix(5, 0), X = 14, Y = 1.3 },
                new Key { Matrix = new Matrix(2, 0), X = 0, Y = 2.3 },
                new Key { Matrix = new Matrix(2, 1), X = 1, Y = 2.3 },
                new Key { Matrix = new Matrix(2, 2), X = 2, Y = 2.1 },
                new Key { Matrix = new Matrix(2, 3), X = 3, Y = 2 },
                new Key { Matrix = new Matrix(2, 4), X = 4, Y = 2.1 },
                new Key { Matrix = new Matrix(2, 5), X = 5, Y = 2.2 },
                new Key { Matrix = new Matrix(6, 5), X = 9, Y = 2.2 },
                new Key { Matrix = new Matrix(6, 4), X = 10, Y = 2.1 },
                new Key { Matrix = new Matrix(6, 3), X = 11, Y = 2 },
                new Key { Matrix = new Matrix(6, 2), X = 12, Y = 2.1 },
                new Key { Matrix = new Matrix(6, 1), X = 13, Y = 2.3 },
                new Key { Matrix = new Matrix(6, 0), X = 14, Y = 2.3 },
                new Key { Matrix = new Matrix(3, 3), X = 4, Y = 3.7 },
                new Key { Matrix = new Matrix(3, 4), X = 5, Y = 3.7 },
                new Key { Matrix = new Matrix(3, 5), Height = 1.5, X = 6, Y = 3.2 },
                new Key { Matrix = new Matrix(7, 5), Height = 1.5, X = 8, Y = 3.2 },
                new Key { Matrix = new Matrix(7, 4), X = 9, Y = 3.7 },
                new Key { Matrix = new Matrix(7, 3), X = 10, Y = 3.7 },
            };

            expectedKbd.Layouts = new Dictionary<string, KeyLayout>
            {
                { layoutSplit3x5_3Name, new KeyLayout { Layout = layoutSplit3x5_3 } },
                { layoutSplit3x6_3Name, new KeyLayout { Layout = layoutSplit3x6_3 } },
            };

            // rgb_matrix
            expectedKbd.RgbMatrix = new RgbMatrix
            {
                Driver = RgbMatrixDriver.ws2812,
                MaxBrightness = 120,
            };

            // rgblight
            expectedKbd.Rgblight = new Rgblight
            {
                MaxBrightness = 120,
            };

            kbd.Should().BeEquivalentTo(expectedKbd);
        }

        [Fact]
        public void DeserializeSplitKeyboardTest2()
        {
            var file = Path.Combine(QmkPath.GetQmkKeyboardsRoot(), @"crkbd\rev1\keyboard.json");

            var json = File.ReadAllText(file);

            var kbd = QmkJsonSerializer.Deserialize(json);

            var expectedKbd = new Keyboard
            {
                KeyboardName = "Corne",
            };

            // usb
            expectedKbd.Usb = new Usb
            {
                Pid = 0x0001,
                DeviceVersion = new(0, 0, 1),
            };

            // features
            expectedKbd.Features = new Features
            {
                Rgblight = true,
            };

            // build
            expectedKbd.Build = new Build
            {
                Lto = true,
            };

            // matrix_pins
            expectedKbd.MatrixPins = new MatrixPins
            {
                Cols = [McuPin.F4, McuPin.F5, McuPin.F6, McuPin.F7, McuPin.B1, McuPin.B3],
                Rows = [McuPin.D4, McuPin.C6, McuPin.D7, McuPin.E6],
            };

            // diode_direction
            expectedKbd.DiodeDirection = DiodeDirection.COL2ROW;

            // split
            expectedKbd.Split = new Split
            {
                Serial = new SplitSerial { Pin = McuPin.D2 },
                Transport = new SplitTransport { Sync = new SplitTransportSync { MatrixState = true } },
            };

            //rbglight
            expectedKbd.Rgblight = new Rgblight
            {
                LedCount = 54,
                SplitCount = new SplitCount(27, 27),
            };

            // ws2812
            expectedKbd.WS2812 = new WS2812
            {
                Pin = McuPin.D3,
            };

            // rgb_matrix
            expectedKbd.RgbMatrix = new RgbMatrix
            {
                SplitCount = new SplitCount(27, 27),
                Layout = new[]
                {
                    new RgbLed { X = 85, Y = 16, Flags = 2 },
                    new RgbLed { X = 50, Y = 13, Flags = 2 },
                    new RgbLed { X = 16, Y = 20, Flags = 2 },
                    new RgbLed { X = 16, Y = 38, Flags = 2 },
                    new RgbLed { X = 50, Y = 48, Flags = 2 },
                    new RgbLed { X = 85, Y = 52, Flags = 2 },
                    new RgbLed { Matrix = new Matrix(3, 5), X = 95, Y = 63, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(2, 5), X = 85, Y = 39, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(1, 5), X = 85, Y = 21, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(0, 5), X = 85, Y = 4, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(0, 4), X = 68, Y = 2, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(1, 4), X = 68, Y = 19, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(2, 4), X = 68, Y = 37, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(3, 4), X = 80, Y = 58, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(3, 3), X = 60, Y = 55, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(2, 3), X = 50, Y = 35, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(1, 3), X = 50, Y = 13, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(0, 3), X = 50, Y = 0, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(0, 2), X = 33, Y = 3, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(1, 2), X = 33, Y = 20, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(2, 2), X = 33, Y = 37, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(2, 1), X = 16, Y = 42, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(1, 1), X = 16, Y = 24, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(0, 1), X = 16, Y = 7, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(0, 0), X = 0, Y = 7, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(1, 0), X = 0, Y = 24, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(2, 0), X = 0, Y = 41, Flags = 1 },
                    new RgbLed { X = 139, Y = 16, Flags = 2 },
                    new RgbLed { X = 174, Y = 13, Flags = 2 },
                    new RgbLed { X = 208, Y = 20, Flags = 2 },
                    new RgbLed { X = 208, Y = 38, Flags = 2 },
                    new RgbLed { X = 174, Y = 48, Flags = 2 },
                    new RgbLed { X = 139, Y = 52, Flags = 2 },
                    new RgbLed { Matrix = new Matrix(7, 5), X = 129, Y = 63, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(6, 5), X = 139, Y = 39, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(5, 5), X = 139, Y = 21, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(4, 5), X = 139, Y = 4, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(4, 4), X = 156, Y = 2, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(5, 4), X = 156, Y = 19, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(6, 4), X = 156, Y = 37, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(7, 4), X = 144, Y = 58, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(7, 3), X = 164, Y = 55, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(6, 3), X = 174, Y = 35, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(5, 3), X = 174, Y = 13, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(4, 3), X = 174, Y = 0, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(4, 2), X = 191, Y = 3, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(5, 2), X = 191, Y = 20, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(6, 2), X = 191, Y = 37, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(6, 1), X = 208, Y = 42, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(5, 1), X = 208, Y = 24, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(4, 1), X = 208, Y = 7, Flags = 4 },
                    new RgbLed { Matrix = new Matrix(4, 0), X = 224, Y = 7, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(5, 0), X = 224, Y = 24, Flags = 1 },
                    new RgbLed { Matrix = new Matrix(6, 0), X = 224, Y = 41, Flags = 1 },
                },
            };

            // development_board
            expectedKbd.DevelopmentBoard = DevelopmentBoard.promicro;

            kbd.Should().BeEquivalentTo(expectedKbd);
        }
    }
}
