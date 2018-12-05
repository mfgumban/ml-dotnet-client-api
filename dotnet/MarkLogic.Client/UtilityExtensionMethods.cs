using System;
using System.Globalization;

namespace MarkLogic.Client
{
    public static class UtilityExtensionMethods
    {
        public static string ToISO8601_7Decimals(this DateTime value)
        {
            return value.ToString("o", CultureInfo.InvariantCulture);
        }

        public static string ToISO8601_3Decimals(this DateTime value)
        {
            return value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
        }
    }
}
