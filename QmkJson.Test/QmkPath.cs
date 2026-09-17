namespace QmkJson.Test
{
    internal static class QmkPath
    {
        public static string GetQmkRoot()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "ProjectDirPath.txt");

            using var sr = new StreamReader(path);
            var projectDirPath = sr.ReadToEnd().Trim();

            return Path.GetFullPath(Path.Combine(projectDirPath, @"..\ref\qmk_firmware"));
        }

        public static string GetQmkKeyboardsRoot()
        {
            return Path.Combine(GetQmkRoot(), "keyboards");
        }
    }
}
