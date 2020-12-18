using System;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.DataServices
{
    public class AtomicNullableTypeTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public AtomicNullableTypeTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.BooleanTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void Boolean(bool? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnBoolean(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.IntTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void Int(int? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.UnsignedIntTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void UnsignedInt(uint? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.LongTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void Long(long? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.UnsignedLongTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void UnsignedLong(ulong? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnUnsignedLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.FloatTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void Float(float? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DoubleTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void Double(double? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DecimalTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void DecimalValid(decimal? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DecimalInvalidTheories), parameters: false, MemberType = typeof(AtomicTypeTheories))]
        public async void DecimalInvalid(decimal? value)
        {
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await AtomicNullableTypeService.Create(DbClient).ReturnDecimal(value));
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DateTimeTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void DateTime(DateTime? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnDateTime(value);
            //OutputResults(value.ToString("o", CultureInfo.InvariantCulture), result.ToString("o", CultureInfo.InvariantCulture));
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.DateTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void Date(DateTime? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnDate(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.TimeTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void Time(DateTime? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnTime(value);
            //OutputResults(value.ToString("o", CultureInfo.InvariantCulture), result.ToString("o", CultureInfo.InvariantCulture));
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(AtomicTypeTheories.TimeSpanTheories), parameters: true, MemberType = typeof(AtomicTypeTheories))]
        public async void TimeSpan(TimeSpan? value)
        {
            var result = await AtomicNullableTypeService.Create(DbClient).ReturnTimeSpan(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }
    }
}
