using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests
{
    public class TestServiceTest : IClassFixture<DatabaseClientFixture>
    {
        private readonly DatabaseClientFixture _dbClientFixture;
        private readonly ITestOutputHelper _output;

        public TestServiceTest(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
        {
            _dbClientFixture = dbClientFixture;
            _output = output;
        }

        private IDatabaseClient DbClient => _dbClientFixture.DbClient;

        [Fact]
        public async void TestReturnNone()
        {
            await TestService.Create(DbClient).returnNone();
        }

        [Fact]
        public async void TestReturnMultipleAtomic()
        {
            var value1 = "the quick brown fox";
            var value2 = 1234;
            var value3 = DateTime.Now;
            var response = await TestService.Create(DbClient).returnMultipleAtomic(value1, value2, value3);
            _output.WriteLine(response);

            var results = response.Split("\n");
            Assert.Equal(3, results.Length);
            Assert.Equal(value1, results[0]);
            Assert.Equal(value2.ToString(), results[1]);
            Assert.Equal(value3.ToISO8601_3Decimals(), results[2]);
        }

        [Fact]
        public async void TestReturnMultiValue()
        {
            var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var results = await TestService.Create(DbClient).returnMultiValue(values);
            results.ToList().ForEach(r => _output.WriteLine(r.ToString()));

            Assert.Equal(values, results);
        }

        [Fact]
        public async void TestReturnDateTime()
        {
            var value = DateTime.Now;
            var result = await TestService.Create(DbClient).returnDateTime(value);
            _output.WriteLine(result.ToISO8601_3Decimals());

            Assert.Equal(value.ToISO8601_3Decimals(), result.ToISO8601_3Decimals());
        }
    }
}
