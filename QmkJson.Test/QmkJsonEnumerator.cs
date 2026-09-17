namespace QmkJson.Test
{
    internal static class QmkJsonEnumerator
    {
        private static readonly string[] _targets = ["keyboard", "info"];

        public static IEnumerable<string> Enumerate()
        {
            foreach (var file in Directory.EnumerateFiles(QmkPath.GetQmkKeyboardsRoot(), "*.json", SearchOption.AllDirectories))
            {
                var name = Path.GetFileNameWithoutExtension(file);

                if (!_targets.Contains(name, StringComparer.OrdinalIgnoreCase)) continue;

                yield return file;
            }
        }
    }
}
