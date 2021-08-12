using MarkLogic.Client.DataService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkLogic.Client.Tests.DataServices
{
    public class AtomicTypeTheories
    {
        private static IEnumerable<object[]> TestValues<T>(bool withNull, params T[] values)
        {
            var testValues = values.Select(value => new object[] { value }).ToList();
            if (withNull)
                testValues.Add(new object[] { null });
            return testValues;
        }

        public static IEnumerable<object[]> BooleanTheories(bool withNull)
        {
            return TestValues(withNull: withNull, 
                true, 
                false);
        }

        public static IEnumerable<object[]> StringTheories(bool withNull)
        {
            return TestValues(withNull: withNull, 
                "", 
                " ", 
                "The quick brown fox jumped over the lazy dog.", 
                "\n\t\r\f", 
                "&amp;");
        }

        public static IEnumerable<object[]> IntTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                0,
                1,
                -1,
                int.MinValue,
                int.MaxValue);
        }

        public static IEnumerable<object[]> UnsignedIntTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                (uint)0,
                uint.MinValue,
                uint.MaxValue);
        }

        public static IEnumerable<object[]> LongTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                0,
                1,
                -1,
                long.MinValue,
                long.MaxValue);
        }

        public static IEnumerable<object[]> UnsignedLongTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                (ulong)0,
                ulong.MinValue,
                ulong.MaxValue);
        }

        public static IEnumerable<object[]> FloatTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                0.0f,
                1.0f,
                -1.0f,
                float.MinValue,
                float.MaxValue,
                float.Epsilon,
                float.NaN,
                float.NegativeInfinity,
                float.PositiveInfinity);
        }

        public static IEnumerable<object[]> DoubleTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                0.0,
                1.0,
                -1.0,
                double.MinValue,
                double.MaxValue,
                //double.Epsilon, // TODO: failing on Mac; post inquiry to Engineering
                double.NaN,
                double.NegativeInfinity,
                double.PositiveInfinity);
        }

        public static IEnumerable<object[]> DecimalTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                decimal.Zero,
                decimal.One,
                decimal.MinusOne,
                // MarkLogic xs:decimal has different lower and upper bounds compared to C# decimal
                Marshal.MinDecimal,
                Marshal.MaxDecimal);
        }

        public static IEnumerable<object[]> DecimalInvalidTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                // MarkLogic xs:decimal has different lower and upper bounds compared to C# decimal
                decimal.MinValue,
                decimal.MaxValue);
        }

        private enum DateTimeTestType { DateTime = 0, Date, Time };

        private static DateTime[] MakeDateTimeTests(DateTimeTestType testDataType)
        {
            var dt = new DateTime(1980, 9, 10);
            var dtLeap = new DateTime(2020, 2, 29);
            var dtMin = System.DateTime.MinValue;
            var dtMax = System.DateTime.MaxValue;
            // NOTE:
            // As per docs: https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-2.2#System_DateTime__ctor_System_Int32_System_Int32_System_Int32_System_Int32_System_Int32_System_Int32_System_Int32_
            // the constructor will only take 0-999 msecs.  However, DateTime.MaxValue will actually have a msec value
            // of 9999999.  To this effect, the "max datetime" test will truncate the msecs since the constructor
            // won't allow msec values more than 999.
            dtMax = new DateTime(dtMax.Year, dtMax.Month, dtMax.Day, dtMax.Hour, dtMax.Minute, dtMax.Second, 999);
            var data = new[]
            {
                dt,
                dtMin,
                dtMax,
                dtLeap,
                new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 1),
                new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59),
                new DateTime(dt.Year, dt.Month, dt.Day, 1, 1, 1, 1), // min msec
                new DateTime(dt.Year, dt.Month, dt.Day, 1, 1, 1, 999), // max msec (for DateTime struct)
                new DateTime(dt.Year, dt.Month, dt.Day, 1, 1, 1, 120), // msec with trailing zero
                new DateTime(dt.Year, dt.Month, dt.Day, 1, 1, 1, 500), // msec with trailing zeros
            };
            switch (testDataType)
            {
                case DateTimeTestType.DateTime:
                    return data;
                case DateTimeTestType.Date:
                    return data.Select(v => v.Date)
                        .Distinct()
                        .ToArray();
                case DateTimeTestType.Time:
                    return data.Select(v => new DateTime(dtMin.Year, dtMin.Month, dtMin.Day, v.Hour, v.Minute, v.Second, v.Millisecond))
                        .Distinct()
                        .ToArray();
                default:
                    throw new InvalidOperationException("Invalid dataType.");
            }
        }

        public static IEnumerable<object[]> DateTimeTheories(bool withNull)
        {
            return TestValues(withNull: withNull, values: MakeDateTimeTests(DateTimeTestType.DateTime));
        }

        public static IEnumerable<object[]> DateTheories(bool withNull)
        {
            return TestValues(withNull: withNull, values: MakeDateTimeTests(DateTimeTestType.Date));
        }

        public static IEnumerable<object[]> TimeTheories(bool withNull)
        {
            return TestValues(withNull: withNull, values: MakeDateTimeTests(DateTimeTestType.Time));
        }

        public static IEnumerable<object[]> TimeSpanTheories(bool withNull)
        {
            return TestValues(withNull: withNull,
                System.TimeSpan.MinValue,
                System.TimeSpan.MaxValue,
                System.TimeSpan.Zero,
                new TimeSpan(356 * 2, 23, 59, 59));
        }
    }
}
