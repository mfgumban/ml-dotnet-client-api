using System;
using System.Globalization;
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

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.BooleanTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void Boolean(bool value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnBoolean(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.StringTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void String(string value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnString(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.IntTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void Int(int value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.UnsignedIntTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void UnsignedInt(uint value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.LongTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void Long(long value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.UnsignedLongTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void UnsignedLong(ulong value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnUnsignedLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.FloatTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void Float(float value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DoubleTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void Double(double value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DecimalTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void DecimalValid(decimal value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DecimalInvalidTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void DecimalInvalid(decimal value)
        {
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await AtomicTypeService.Create(DbClient).ReturnDecimal(value));
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DateTimeTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void DateTime(DateTime value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDateTime(value);
            OutputResults(value.ToString("o", CultureInfo.InvariantCulture), result.ToString("o", CultureInfo.InvariantCulture));
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DateTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void Date(DateTime value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnDate(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.TimeTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void Time(DateTime value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnTime(value);
            OutputResults(value.ToString("o", CultureInfo.InvariantCulture), result.ToString("o", CultureInfo.InvariantCulture));
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.TimeSpanTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void TimeSpan(TimeSpan value)
        {
            var result = await AtomicTypeService.Create(DbClient).ReturnTimeSpan(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }
    }
}
