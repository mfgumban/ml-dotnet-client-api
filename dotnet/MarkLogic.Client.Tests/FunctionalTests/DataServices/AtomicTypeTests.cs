using MarkLogic.Client.Tests.DataServices;
using System;
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

        [Fact]
        public async void TestNullableValueType()
        {
            var result = await AtomicTypeTestsService.Create(DbClient).returnNullableValueType(null);
            Assert.Null(result);
        }

        [Fact]
        public async void TestNullableValueTypeNullableNoValue()
        {
            var value = new int?();
            var result = await AtomicTypeTestsService.Create(DbClient).returnNullableValueType(value);
            Assert.Null(result);
        }

        [Fact]
        public async void TestNullableValueTypeNonNull()
        {
            var value = 1234;
            var result = await AtomicTypeTestsService.Create(DbClient).returnNullableValueType(value);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnString()
        {
            var value = "The quick brown fox jumped over the lazy dog.";
            var result = await AtomicTypeTestsService.Create(DbClient).returnString(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnBooleanTrue()
        {
            var value = true;
            var result = await AtomicTypeTestsService.Create(DbClient).returnBoolean(value);
            
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnBooleanFalse()
        {
            var value = false;
            var result = await AtomicTypeTestsService.Create(DbClient).returnBoolean(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnIntMin()
        {
            var value = int.MinValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnIntMax()
        {
            var value = int.MaxValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedIntMin()
        {
            var value = uint.MinValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedIntMax()
        {
            var value = uint.MaxValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnLongMin()
        {
            var value = long.MinValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnLongMax()
        {
            var value = long.MaxValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedLongMin()
        {
            var value = ulong.MinValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnUnsignedLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedLongMax()
        {
            var value = ulong.MaxValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnUnsignedLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatMin()
        {
            var value = float.MinValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatMax()
        {
            var value = float.MaxValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatNaN()
        {
            var value = float.NaN;
            var result = await AtomicTypeTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatPositiveInfinity()
        {
            var value = float.PositiveInfinity;
            var result = await AtomicTypeTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatNegativeInfinity()
        {
            var value = float.NegativeInfinity;
            var result = await AtomicTypeTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleMin()
        {
            var value = double.MinValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleMax()
        {
            var value = double.MaxValue;
            var result = await AtomicTypeTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleNaN()
        {
            var value = double.NaN;
            var result = await AtomicTypeTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoublePositiveInfinity()
        {
            var value = double.PositiveInfinity;
            var result = await AtomicTypeTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleNegativeInfinity()
        {
            var value = double.NegativeInfinity;
            var result = await AtomicTypeTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDecimalOne()
        {
            var value = decimal.One;
            var result = await AtomicTypeTestsService.Create(DbClient).returnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDecimalMin()
        {
            var value = decimal.MinValue;
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await AtomicTypeTestsService.Create(DbClient).returnDecimal(value));
        }

        [Fact]
        public async void TestReturnDecimalMax()
        {
            var value = decimal.MaxValue;
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await AtomicTypeTestsService.Create(DbClient).returnDecimal(value));
        }

        [Fact]
        public async void TestReturnDateTime()
        {
            var value = DateTime.Now.AsISO8601();
            var result = await AtomicTypeTestsService.Create(DbClient).returnDateTime(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDateTimeMin()
        {
            var value = DateTime.MinValue.AsISO8601();
            var result = await AtomicTypeTestsService.Create(DbClient).returnDateTime(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDateTimeMax()
        {
            var value = DateTime.MaxValue.AsISO8601();
            var result = await AtomicTypeTestsService.Create(DbClient).returnDateTime(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDate()
        {
            var value = DateTime.Now.Date;
            var result = await AtomicTypeTestsService.Create(DbClient).returnDate(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnTime()
        {
            var value = DateTime.Now.AsISO8601();
            var result = await AtomicTypeTestsService.Create(DbClient).returnDateTime(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestTimeSpan()
        {
            var value = new TimeSpan(5, 23, 15, 34, 0);
            var result = await AtomicTypeTestsService.Create(DbClient).returnTimeSpan(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }
    }
}
