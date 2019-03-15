namespace MarkLogic.Client.Tools
{
    public static class ExtensionMethods
    {
        public static string Capitalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            var chars = value.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }

        public static void BeginScope(this IndentedTextWriter writer)
        {
            writer.WriteLine("{");
            writer.AddIndent();
        }

        public static void EndScope(this IndentedTextWriter writer)
        {
            writer.RemoveIndent();
            writer.WriteLine("}");
        }

        public static void WriteCommentSummary(this IndentedTextWriter writer, string summary)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine($"/// {summary}");
            writer.WriteLine("/// </summary>");
        }

        public static void WriteCommentParam(this IndentedTextWriter writer, string paramName, string summary)
        {
            writer.WriteLine($"/// <param name=\"{paramName}\">{summary}</param>");
        }

        public static void WriteCommentReturns(this IndentedTextWriter writer, string summary)
        {
            writer.WriteLine($"/// <returns>{summary}</param>");
        }
    }
}
