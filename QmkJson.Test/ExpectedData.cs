namespace QmkJson.Test
{
    internal static class ExpectedData
    {
        private static readonly string AssemblyPath = AppContext.BaseDirectory;
        private static readonly string ExpectedDataRoot = Path.Combine(AssemblyPath, "Resources", "Expected");

        public static string ReadAllDefinedJson()
        {
            return File.ReadAllText(Path.Combine(ExpectedDataRoot, "all_defined.json"));
        }
    }
}
