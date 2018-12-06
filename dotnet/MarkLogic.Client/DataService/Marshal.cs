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

        public string Value { get; private set; }

        public string MediaType { get; private set; }

        public static Marshal String(string value)
        {
            return new Marshal(value);
        }

        public static Marshal Integer(int value)
        {
            return new Marshal(Convert.ToString(value));
        }

        public static Marshal DateTime(DateTime value)
        {
            return new Marshal(value.ToISO8601_3Decimals());
        }

        public static Marshal TextReaderAsXML(TextReader reader)
        {
            return new Marshal(reader.ReadToEnd(), MediaTypes.Xml); // TODO: see if we can do "side-effect-free"
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