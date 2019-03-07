using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace MarkLogic.Client.DataService
{
    public static class Unmarshal
    {
        public static bool Boolean(string value)
        {
            return XmlConvert.ToBoolean(value);
        }

        public static string String(string value)
        {
            return value;
        }

        public static int Integer(string value)
        {
            return XmlConvert.ToInt32(value);
        }

        public static uint UnsignedInteger(string value)
        {
            return XmlConvert.ToUInt32(value);
        }

        public static long Long(string value)
        {
            return XmlConvert.ToInt64(value);
        }

        public static ulong UnsignedLong(string value)
        {
            return XmlConvert.ToUInt64(value);
        }

        public static float Float(string value)
        {
            return XmlConvert.ToSingle(value);
        }

        public static double Double(string value)
        {
            return XmlConvert.ToDouble(value);
        }

        public static decimal Decimal(string value)
        {
            return XmlConvert.ToDecimal(value);
        }

        public static DateTime DateTime(string value)
        {
            return XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.RoundtripKind);
        }

        public static DateTime Date(string value)
        {
            return System.DateTime.ParseExact(value, "yyyy-MM-dd", null);
        }

        public static DateTime Time(string value)
        {
            return System.DateTime.ParseExact(value, "HH:mm:ss.fff", null);
        }

        public static TimeSpan TimeSpan(string value)
        {
            return XmlConvert.ToTimeSpan(value);
        }

        public static JObject JsonObject(string value)
        {
            return JObject.Parse(value);
        }

        public static JArray JsonArray(string value)
        {
            return JArray.Parse(value);
        }
    }
}