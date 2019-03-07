using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace MarkLogic.Client.DataService
{
    public class Marshal
    {
        public static class MediaTypes
        {
            public const string Text = "text/plain";
            public const string Json = "application/json";
            public const string Xml = "application/xml";
            public const string Binary = "application/octet-stream";
        }

        /// <summary>
        /// The minimum value for xs:decimal in MarkLogic.
        /// </summary>
        public static readonly decimal MinDecimal = decimal.Parse("-18446744073709551615");

        /// <summary>
        /// The maximum value for xs:decimal in MarkLogic.
        /// </summary>
        public static readonly decimal MaxDecimal = 18446744073709551615;

        protected Marshal(string marshalledValue, string mediaType = MediaTypes.Text)
        {
            Value = marshalledValue;
            MediaType = mediaType;
        }

        protected Marshal(Stream marshalledStream, string mediaType)
        {
            Stream = marshalledStream;
            MediaType = mediaType;
        }

        public string Value { get; private set; }

        public string MediaType { get; private set; }

        public Stream Stream { get; private set; }

        public bool IsStream => Stream != null;

        public bool HasValue => IsStream || Value != null;

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
    }
}