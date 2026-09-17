using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace QmkJson.Test
{
    public partial class CheckJsons
    {
        [Fact]
        public void CheckInvalidJsons()
        {
            var list = new List<JsonErrorInfo>();

            foreach (var file in QmkJsonEnumerator.Enumerate())
            {
                var relativePath = Path.GetRelativePath(QmkPath.GetQmkKeyboardsRoot(), file);

                var json = string.Empty;

                using (var sr = new StreamReader(file))
                {
                    json = sr.ReadToEnd();
                }

                try
                {
                    var kbd = QmkJsonSerializer.Deserialize(json);
                }
                catch (JsonException ex)
                {
                    var count = 0;
                    var offset = 2;

                    var errorLine = ex.LineNumber + 1;

                    var start = errorLine - offset;
                    var end = errorLine + offset;

                    var error = new JsonErrorInfo
                    {
                        FileName = relativePath,
                        ErrorMessage = ex.Message,
                        ErrorLineNumber = errorLine
                    };

                    using (var sr = new StreamReader(file))
                    {
                        var lines = new List<LineInfo>();

                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            count++;

                            if (count >= start && count <= end)
                            {
                                lines.Add(new(count, line));
                            }

                            if (count > end) break;
                        }

                        error.ErrorContext = lines;
                    }

                    list.Add(error);
                }
            }

            var tmpRoot = Path.Combine(AppContext.BaseDirectory, "json_tmp");

            if (!Directory.Exists(tmpRoot))
            {
                Directory.CreateDirectory(tmpRoot);
            }

            var ijFileName = "invalid_json.txt";
            var ejFileName = "exclude_json.txt";

            var ijPath = Path.Combine(tmpRoot, ijFileName);
            var ejPath = Path.Combine(tmpRoot, ejFileName);

            using (var ijSW = new StreamWriter(ijPath, false))
            {
                foreach (var error in list)
                {
                    ijSW.WriteLine(error.ToString());
                }
            }


            using (var ejSW = new StreamWriter(ejPath, false))
            {
                foreach (var errors in list.GroupBy(x => x.ErrorType))
                {
                    switch (errors.Key)
                    {
                        case ErrorType.UndefinedProperty:
                            ejSW.WriteLine("// Undefined property");
                            break;
                        case ErrorType.MissingComma:
                            ejSW.WriteLine("// Missing comma");
                            break;
                        case ErrorType.InvalidEscaping:
                            ejSW.WriteLine("// Invalid escaping");
                            break;
                        default:
                            ejSW.WriteLine("// Other");
                            break;
                    }

                    foreach (var error in errors)
                    {
                        ejSW.WriteLine($@"if (path.EndsWith(@""{error.FileName}"", StringComparison.OrdinalIgnoreCase)) return true; // [LineNumber:{error.ErrorLine?.LineNumber}] | {error.ErrorLine?.Text} | {error.ErrorMessage}");
                    }
                    ejSW.WriteLine();
                }
            }
        }

        private enum ErrorType
        {
            UndefinedProperty,
            MissingComma,
            InvalidEscaping,
            Other,
        }

        private class LineInfo
        {
            public long LineNumber { get; set; }
            public string? Text { get; set; }

            public LineInfo(int lineNumber, string? text)
            {
                this.LineNumber = lineNumber;
                this.Text = text;
            }
        }

        private partial class JsonErrorInfo
        {
            public string FileName { get; set; } = string.Empty;
            public long? ErrorLineNumber { get; set; }
            public LineInfo? ErrorLine => this.GetErrorLine();
            public string? ErrorMessage { get; set; }
            public ErrorType ErrorType => this.GetErrorType();
            public IEnumerable<LineInfo> ErrorContext { get; set; } = [];

            public override string ToString()
            {
                var builder = new StringBuilder();

                var maxLength = this.ErrorContext.Max(x => x.Text?.Length ?? 0);

                builder.AppendLine(this.FileName);

                foreach (var line in this.ErrorContext)
                {
                    builder.AppendLine($"[{line.LineNumber:d4}]|{(line.LineNumber == this.ErrorLineNumber ? $"{line.Text?.PadRight(maxLength)}|{this.ErrorMessage}" : line.Text)}");
                }

                return builder.ToString();
            }

            private ErrorType GetErrorType()
            {
                if (string.IsNullOrEmpty(this.ErrorMessage)) return ErrorType.Other;

                if (UndefinedPropertyRegex().IsMatch(this.ErrorMessage))
                {
                    return ErrorType.UndefinedProperty;
                }
                else if (MissingCommaRegex().IsMatch(this.ErrorMessage))
                {
                    return ErrorType.MissingComma;
                }
                else if (InvalidEscapingRegex().IsMatch(this.ErrorMessage))
                {
                    return ErrorType.InvalidEscaping;
                }
                else
                {
                    return ErrorType.Other;
                }
            }

            private LineInfo? GetErrorLine()
            {
                return this.GetErrorType() switch
                {
                    ErrorType.MissingComma => this.ErrorContext.FirstOrDefault(x => x.LineNumber <= this.ErrorLineNumber && (!x.Text?.TrimEnd().EndsWith(",") ?? false)),
                    _ => this.ErrorContext.FirstOrDefault(x => x.LineNumber == this.ErrorLineNumber),
                };
            }

            [GeneratedRegex(@"^The JSON property '.+' could not be mapped.*$")]
            private static partial Regex UndefinedPropertyRegex();
            [GeneratedRegex(@"^'.+' is invalid after a value.*$")]
            private static partial Regex MissingCommaRegex();
            [GeneratedRegex(@"^'.+' is an invalid escapable character.*$")]
            private static partial Regex InvalidEscapingRegex();
        }
    }
}
