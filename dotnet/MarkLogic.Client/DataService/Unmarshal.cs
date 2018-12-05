using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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
    }
}