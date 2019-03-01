using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace MarkLogic.Client.DataService
{
    public class Marshal
    {
        public static class MediaTypes
        {
            public const string Text = "text/plain";
            public const string Json = "application/json";
            public const string Xml = "application/xml";
        }

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

        public static Marshal Boolean(bool value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal String(string value)
        {
            return new Marshal(value);
        }

        public static Marshal Integer(int value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal UnsignedInteger(uint value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal Long(long value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal UnsignedLong(ulong value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal Float(float value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal Double(double value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal Decimal(decimal value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal DateTime(DateTime value)
        {
            return new Marshal(value.ToISO8601_DateTime_3Decimals());
        }

        public static Marshal Date(DateTime value)
        {
            return new Marshal(value.ToISO8601_Date());
        }

        public static Marshal Time(DateTime value)
        {
            return new Marshal(value.ToISO8601_Time_3Decimals());
        }

        public static Marshal StreamAsXml(Stream stream)
        {
            return new Marshal(stream, MediaTypes.Xml);
        }

        public static Marshal StreamAsJson(Stream stream)
        {
            return new Marshal(stream, MediaTypes.Json);
        }

        public static Marshal JsonObject(JObject value)
        {
            return new Marshal(value.ToString(Formatting.None), MediaTypes.Json);
        }

        public static Marshal JsonArray(JArray value)
        {
            return new Marshal(value.ToString(Formatting.None), MediaTypes.Json);
        }
    }
}