﻿using MarkLogic.Client.Tests.DataServices;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests.DataServices
{
    public class AtomicTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public AtomicTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        private void OutputResults<T>(T value, T result)
        {
            Output.WriteLine("Value: {0} Return: {1}", value, result);
        }

        [Fact]
        public async void TestReturnString()
        {
            var value = "The quick brown fox jumped over the lazy dog.";
            var result = await AtomicTestsService.Create(DbClient).returnString(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnBooleanTrue()
        {
            var value = true;
            var result = await AtomicTestsService.Create(DbClient).returnBoolean(value);
            
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnBooleanFalse()
        {
            var value = false;
            var result = await AtomicTestsService.Create(DbClient).returnBoolean(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnIntMin()
        {
            var value = int.MinValue;
            var result = await AtomicTestsService.Create(DbClient).returnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnIntMax()
        {
            var value = int.MaxValue;
            var result = await AtomicTestsService.Create(DbClient).returnInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedIntMin()
        {
            var value = uint.MinValue;
            var result = await AtomicTestsService.Create(DbClient).returnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedIntMax()
        {
            var value = uint.MaxValue;
            var result = await AtomicTestsService.Create(DbClient).returnUnsignedInteger(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnLongMin()
        {
            var value = long.MinValue;
            var result = await AtomicTestsService.Create(DbClient).returnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnLongMax()
        {
            var value = long.MaxValue;
            var result = await AtomicTestsService.Create(DbClient).returnLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedLongMin()
        {
            var value = ulong.MinValue;
            var result = await AtomicTestsService.Create(DbClient).returnUnsignedLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnUnsignedLongMax()
        {
            var value = ulong.MaxValue;
            var result = await AtomicTestsService.Create(DbClient).returnUnsignedLong(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatMin()
        {
            var value = float.MinValue;
            var result = await AtomicTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatMax()
        {
            var value = float.MaxValue;
            var result = await AtomicTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatNaN()
        {
            var value = float.NaN;
            var result = await AtomicTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatPositiveInfinity()
        {
            var value = float.PositiveInfinity;
            var result = await AtomicTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnFloatNegativeInfinity()
        {
            var value = float.NegativeInfinity;
            var result = await AtomicTestsService.Create(DbClient).returnFloat(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleMin()
        {
            var value = double.MinValue;
            var result = await AtomicTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleMax()
        {
            var value = double.MaxValue;
            var result = await AtomicTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleNaN()
        {
            var value = double.NaN;
            var result = await AtomicTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoublePositiveInfinity()
        {
            var value = double.PositiveInfinity;
            var result = await AtomicTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDoubleNegativeInfinity()
        {
            var value = double.NegativeInfinity;
            var result = await AtomicTestsService.Create(DbClient).returnDouble(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDecimalOne()
        {
            var value = decimal.One;
            var result = await AtomicTestsService.Create(DbClient).returnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDecimalMin()
        {
            var value = decimal.MinValue;
            var result = await AtomicTestsService.Create(DbClient).returnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDecimalMax()
        {
            var value = decimal.MaxValue;
            var result = await AtomicTestsService.Create(DbClient).returnDecimal(value);
            OutputResults(value, result);
            Assert.Equal(value, result);
        }

        [Fact]
        public async void TestReturnDateTime()
        {
            var value = DateTime.Now;
            var result = await AtomicTestsService.Create(DbClient).returnDateTime(value);
            OutputResults(value.ToISO8601_DateTime_3Decimals(), result.ToISO8601_DateTime_3Decimals());
            Assert.Equal(value.ToISO8601_DateTime_3Decimals(), result.ToISO8601_DateTime_3Decimals());
        }
    }
}
