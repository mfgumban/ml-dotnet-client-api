using System.IO;
using System.Text;

namespace MarkLogic.Client.Tools.Tests
{
    public static class ExtensionMethods
    {
        public static Stream ToStream(this string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value));
        }

        public static Stream CreateCopy(this Stream stream)
        {
            stream.Position = 0;
            var copy = new MemoryStream();
            stream.CopyTo(copy);
            copy.Position = 0;
            return copy;
        }
    }
}
