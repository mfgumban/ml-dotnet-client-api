﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.DataServices
{
    public class AtomicTypeTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public AtomicTypeTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        public static IEnumerable<object[]> NullableValueTypeData()
        {
            return new[]
            {
                //new object[] { null, null }, // removed temporarily
                //new object[] { new int?(), null },
                new object[] { 1234, 1234 },
            };
        }

        [Theory]
        [MemberData(nameof(NullableValueTypeData))]
        public async void NullableValueType(int? value, int? expectedResult)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnNullableValueType(value);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("The quick brown fox jumped over the lazy dog.")]
        [InlineData(" ")]
        [InlineData("\n\t\r\f")]
        [InlineData("&amp;")]
        public async void String(string value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnString(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async void Boolean(bool value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnBoolean(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async void Int(int value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(uint.MinValue)]
        [InlineData(uint.MaxValue)]
        public async void UnsignedInt(uint value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(long.MinValue)]
        [InlineData(long.MaxValue)]
        public async void Long(long value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(ulong.MinValue)]
        [InlineData(ulong.MaxValue)]
        public async void UnsignedLong(ulong value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnUnsignedLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(0.0f)]
        [InlineData(1.0f)]
        [InlineData(-1.0f)]
        [InlineData(float.MinValue)]
        [InlineData(float.MaxValue)]
        [InlineData(float.Epsilon)]
        [InlineData(float.NaN)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity)]
        public async void Float(float value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        //[InlineData(double.Epsilon)] // TODO: failing on Mac; post inquiry to Engineering
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        public async void Double(double value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> DecimalValidData()
        {
            return new[]
            {
                new object[] { decimal.Zero },
                new object[] { decimal.One },
                new object[] { decimal.MinusOne }
            };
        }

        [Theory]
        [MemberData(nameof(DecimalValidData))]
        public async void DecimalValid(decimal value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> DecimalInvalidData()
        {
            return new[]
            {
                new object[] { decimal.MinValue },
                new object[] { decimal.MaxValue }
            };
        }

        [Theory]
        [MemberData(nameof(DecimalInvalidData))]
        public async void DecimalInvalid(decimal value)
        {
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await AtomicTypeService.Create(DbClient).ReturnDecimal(value));
        }

        public enum DateTimeTestDataType { DateTime = 0, Date, Time };

        public static IEnumerable<object[]> DateTimeData(DateTimeTestDataType testDataType)
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
                case DateTimeTestDataType.DateTime:
                    return data.Select(v => new object[] { v });
                case DateTimeTestDataType.Date:
                    return data.Select(v => v.Date).Distinct().Select(v => new object[] { v });
                case DateTimeTestDataType.Time:
                    return data.Select(v => 
                        new DateTime(dtMin.Year, dtMin.Month, dtMin.Day, v.Hour, v.Minute, v.Second, v.Millisecond))
                        .Distinct()
                        .Select(v => new object[] { v });
                default:
                    throw new InvalidOperationException("Invalid dataType.");
            }
        }

        [Theory]
        [MemberData(nameof(DateTimeData), parameters: DateTimeTestDataType.DateTime)]
        public async void DateTime(DateTime value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDateTime(value);
            OutputResults(value.ToString("o", CultureInfo.InvariantCulture), result.ToString("o", CultureInfo.InvariantCulture));
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(DateTimeData), parameters: DateTimeTestDataType.Date)]
        public async void Date(DateTime value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDate(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(DateTimeData), parameters: DateTimeTestDataType.Time)]
        public async void Time(DateTime value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnTime(value);
            OutputResults(value.ToString("o", CultureInfo.InvariantCulture), result.ToString("o", CultureInfo.InvariantCulture));
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> TimeSpanData()
        {
            return new[]
            {
                new object[] { System.TimeSpan.MinValue },
                new object[] { System.TimeSpan.MaxValue },
                new object[] { System.TimeSpan.Zero },
                new object[] { new TimeSpan(356 * 2, 23, 59, 59) }
            };
        }

        [Theory]
        [MemberData(nameof(TimeSpanData))]
        public async void TimeSpan(TimeSpan value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnTimeSpan(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }
    }
}
