using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace MarkLogic.Client.DataService
{
    public static class Unmarshal
    {
        public static string String(string value)
        {
            return value;
        }

        public static int Integer(string value)
        {
            return Convert.ToInt32(value);
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