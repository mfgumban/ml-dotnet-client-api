using MarkLogic.Client.Tests.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests.DataServices
{
    public class AtomicTypeTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public AtomicTypeTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        public static IEnumerable<object[]> TestNullableValueTypeData()
        {
            return new[]
            {
                new object[] { null, null },
                new object[] { 1234, 1234 },
                new object[] { new int?(), null }
            };
        }

        [Theory]
        [MemberData(nameof(TestNullableValueTypeData))]
        public async void TestNullableValueType(int? value, int? expectedResult)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnNullableValueType(value);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("The quick brown fox jumped over the lazy dog.")]
        [InlineData(" ")]
        [InlineData("\0")]
        [InlineData("\n\t\r\f")]
        public async void TestReturnString(string value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnString(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async void TestReturnBoolean(bool value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnBoolean(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async void TestReturnInt(int value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(uint.MinValue)]
        [InlineData(uint.MaxValue)]
        public async void TestReturnUnsignedInt(uint value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(long.MinValue)]
        [InlineData(long.MaxValue)]
        public async void TestReturnLong(long value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(ulong.MinValue)]
        [InlineData(ulong.MaxValue)]
        public async void TestReturnUnsignedLong(ulong value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnUnsignedLong(value);
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
        public async void TestReturnFloat(float value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnFloat(value);
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
        public async void TestReturnDouble(double value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> TestReturnDecimalValidData()
        {
            return new[]
            {
                new object[] { decimal.Zero },
                new object[] { decimal.One },
                new object[] { decimal.MinusOne }
            };
        }

        [Theory]
        [MemberData(nameof(TestReturnDecimalValidData))]
        public async void TestReturnDecimalValid(decimal value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> TestReturnDecimalInvalidData()
        {
            return new[]
            {
                new object[] { decimal.MinValue },
                new object[] { decimal.MaxValue }
            };
        }

        [Theory]
        [MemberData(nameof(TestReturnDecimalInvalidData))]
        public async void TestReturnDecimalInvalid(decimal value)
        {
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await AtomicTypeTestsService.Create(DbClient).returnDecimal(value));
        }

        public enum TestReturnDateTimeDataType { DateTime = 0, Date, Time };

        public static IEnumerable<object[]> TestReturnDateTimeData(TestReturnDateTimeDataType dataType)
        {
            var now = DateTime.Now;
            var data = new[]
            {
                now,
                DateTime.MinValue,
                DateTime.MaxValue,
                new DateTime(now.Year, now.Month, now.Day, 0, 0, 1),
                new DateTime(now.Year, now.Month, now.Day, 23, 59, 59)
            };
            switch (dataType)
            {
                case TestReturnDateTimeDataType.DateTime:
                    return data.Select(dt => new object[] { dt.AsISO8601() });
                case TestReturnDateTimeDataType.Date:
                    return data.Select(dt => new object[] { dt.Date });
                case TestReturnDateTimeDataType.Time:
                    return data.Select(dt => new object[] { new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, dt.Hour, dt.Minute, dt.Second) });
                default:
                    throw new InvalidOperationException("Invalid dataType.");
            }
        }

        [Theory]
        [MemberData(nameof(TestReturnDateTimeData), parameters: TestReturnDateTimeDataType.DateTime)]
        public async void TestReturnDateTime(DateTime value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnDateTime(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(TestReturnDateTimeData), parameters: TestReturnDateTimeDataType.Date)]
        public async void TestReturnDate(DateTime value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnDate(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(TestReturnDateTimeData), parameters: TestReturnDateTimeDataType.Time)]
        public async void TestReturnTime(DateTime value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnTime(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> TestReturnTimeSpanData()
        {
            return new[]
            {
                new object[] { TimeSpan.MinValue },
                new object[] { TimeSpan.MaxValue },
                new object[] { TimeSpan.Zero },
                new object[] { new TimeSpan(356 * 2, 23, 59, 59) }
            };
        }

        [Theory]
        [MemberData(nameof(TestReturnTimeSpanData))]
        public async void TestReturnTimeSpan(TimeSpan value)
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnTimeSpan(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }
    }
}
