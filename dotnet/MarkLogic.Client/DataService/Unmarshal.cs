using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace MarkLogic.Client.DataService
{
    public static class Unmarshal
    {
        public static bool Boolean(string value)
        {
            return Convert.ToBoolean(value);
        }

        public static string String(string value)
        {
            return value;
        }

        public static int Integer(string value)
        {
            return Convert.ToInt32(value);
        }

        public static uint UnsignedInteger(string value)
        {
            return Convert.ToUInt32(value);
        }

        public static long Long(string value)
        {
            return Convert.ToInt64(value);
        }

        public static ulong UnsignedLong(string value)
        {
            return Convert.ToUInt64(value);
        }

        public static float Float(string value)
        {
            return Convert.ToSingle(value);
        }

        public static double Double(string value)
        {
            return Convert.ToDouble(value);
        }

        public static decimal Decimal(string value)
        {
            return Convert.ToDecimal(value);
        }

        public static DateTime DateTime(string value)
        {
            return System.DateTime.Parse(value, null, DateTimeStyles.RoundtripKind);
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