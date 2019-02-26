using System;
using System.Globalization;

namespace MarkLogic.Client
{
    public static class UtilityExtensionMethods
    {
        public static string ToISO8601_DateTime_7Decimals(this DateTime value)
        {
            return value.ToString("o", CultureInfo.InvariantCulture);
        }

        public static string ToISO8601_DateTime_3Decimals(this DateTime value)
        {
            return value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
        }

        public static string ToISO8601_Date(this DateTime value)
        {
            return value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static string ToISO8601_Time_3Decimals(this DateTime value)
        {
            return value.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
    }
}
