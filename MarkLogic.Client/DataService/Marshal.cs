using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace MarkLogic.Client.DataService
{
    public class Marshal
    {
        public enum MediaTypes
        {
            String,
            Text,
            Json,
            Xml,
            Binary
        }
        
        /// <summary>
        /// The minimum value for xs:decimal in MarkLogic.
        /// </summary>
        public static readonly decimal MinDecimal = decimal.Parse("-18446744073709551615");

        /// <summary>
        /// The maximum value for xs:decimal in MarkLogic.
        /// </summary>
        public static readonly decimal MaxDecimal = 18446744073709551615;

        protected Marshal(string marshalledValue, MediaTypes mediaType = MediaTypes.String)
        {
            Value = marshalledValue;
            MediaType = mediaType;
        }

        protected Marshal(Stream marshalledStream, MediaTypes mediaType)
        {
            Stream = marshalledStream;
            MediaType = mediaType;
        }

        public string Value { get; private set; }

        public MediaTypes MediaType { get; private set; }

        public Stream Stream { get; private set; }

        public bool IsStream => Stream != null;

        public bool HasValue => IsStream || Value != null;

        public static Func<T?, Marshal> Nullable<T>(Func<T, Marshal> marshalValue) where T : struct, IComparable
        {
            return new Func<T?, Marshal>((value) => (value == null || !value.HasValue) ? new Marshal(null) : marshalValue(value.Value));
        }

        public static Marshal Boolean(bool value)
        {
            return new Marshal(value ? "true" : "false");
        }

        public static Marshal String(string value)
        {
            return new Marshal(value);
        }

        public static Marshal Integer(int value)
        {
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal UnsignedInteger(uint value)
        {
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal Long(long value)
        {
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal UnsignedLong(ulong value)
        {
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal Float(float value)
        {
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal Double(double value)
        {
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal Decimal(decimal value)
        {
            if (value < MinDecimal || value > MaxDecimal)
            {
                throw new ArgumentOutOfRangeException("value", value, $"MarkLogic xs:decimal will only support values between {MinDecimal} and {MaxDecimal}.");
            }
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal DateTime(DateTime value)
        {
            return new Marshal(value.ToISODateTime());
        }

        public static Marshal Date(DateTime value)
        {
            return new Marshal(value.ToISODate());
        }

        public static Marshal Time(DateTime value)
        {
            return new Marshal(value.ToISOTime());
        }

        public static Marshal TimeSpan(TimeSpan value)
        {
            return new Marshal(XmlConvert.ToString(value));
        }

        public static Marshal StreamAsText(Stream stream)
        {
            return new Marshal(stream, MediaTypes.Text);
        }

        public static Marshal StreamAsXml(Stream stream)
        {
            return new Marshal(stream, MediaTypes.Xml);
        }

        public static Marshal StreamAsJson(Stream stream)
        {
            return new Marshal(stream, MediaTypes.Json);
        }

        public static Marshal StreamAsBinary(Stream stream)
        {
            return new Marshal(stream, MediaTypes.Binary);
        }

        public static Marshal JsonObject(JObject value)
        {
            return new Marshal(value.ToString(Newtonsoft.Json.Formatting.None), MediaTypes.Json);
        }

        public static Marshal JsonArray(JArray value)
        {
            return new Marshal(value.ToString(Newtonsoft.Json.Formatting.None), MediaTypes.Json);
        }

        public static Marshal XmlDocument(XmlDocument value)
        {
            return new Marshal(value.OuterXml, MediaTypes.Xml);
        }

        public static Marshal XDocument(XDocument value)
        {
            return new Marshal(value.ToString(), MediaTypes.Xml);
        }
    }
}