using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MarkLogic.Client
{
    public static class ExtensionMethods
    {
        public static bool EqualsIgnoreCase(this string value, string valueToCompare)
        {
            return value.Equals(valueToCompare, StringComparison.InvariantCultureIgnoreCase);
        }

        public static DateTime AsISO8601(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        public static string ToISODateTime(this DateTime value)
        {
            return XmlConvert.ToString(AsISO8601(value), "yyyy-MM-dd'T'HH:mm:ss.fffK");
        }

        public static string ToISODate(this DateTime value)
        {
            return XmlConvert.ToString(AsISO8601(value), "yyyy-MM-dd");
        }

        public static string ToISOTime(this DateTime value)
        {
            return XmlConvert.ToString(AsISO8601(value), "HH:mm:ss.fff");
        }

        public static string Truncate(this string value, int maxChars, string suffix = "...")
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";
            else
                return value.Length <= maxChars ? value : value.Substring(0, maxChars) + suffix;
        }

        public static XDocument ToXDocument(this XmlDocument document)
        {
            return document.ToXDocument(LoadOptions.None);
        }

        public static XDocument ToXDocument(this XmlDocument document, LoadOptions options)
        {
            using (XmlNodeReader reader = new XmlNodeReader(document))
            {
                return XDocument.Load(reader, options);
            }
        }
    }
}
