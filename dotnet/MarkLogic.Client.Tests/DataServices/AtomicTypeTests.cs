using System;
using System.Collections.Generic;
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
                new object[] { null, null },
                new object[] { 1234, 1234 },
                new object[] { new int?(), null }
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
        [InlineData("\0")]
        [InlineData("\n\t\r\f")]
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
        [InlineData(double.Epsilon)]
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
            var now = System.DateTime.Now;
            var data = new[]
            {
                now,
                System.DateTime.MinValue,
                System.DateTime.MaxValue,
                new DateTime(now.Year, now.Month, now.Day, 0, 0, 1),
                new DateTime(now.Year, now.Month, now.Day, 23, 59, 59),
                new DateTime(now.Year, now.Month, now.Day, 1, 1, 1, 1), // min msec
                new DateTime(now.Year, now.Month, now.Day, 1, 1, 1, 999), // max msec
                new DateTime(now.Year, now.Month, now.Day, 1, 1, 1, 120), // msec with trailing zero
            };
            switch (testDataType)
            {
                case DateTimeTestDataType.DateTime:
                    return data.Select(dt => new object[] { dt.AsISO8601() });
                case DateTimeTestDataType.Date:
                    return data.Select(dt => new object[] { dt.Date });
                case DateTimeTestDataType.Time:
                    return data.Select(dt => new object[] { new DateTime(System.DateTime.MinValue.Year, System.DateTime.MinValue.Month, System.DateTime.MinValue.Day, dt.Hour, dt.Minute, dt.Second) });
                default:
                    throw new InvalidOperationException("Invalid dataType.");
            }
        }

        [Theory]
        [MemberData(nameof(DateTimeData), parameters: DateTimeTestDataType.DateTime)]
        public async void DateTime(DateTime value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDateTime(value);
            OutputResults(value, result);
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
            OutputResults(value, result);
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
