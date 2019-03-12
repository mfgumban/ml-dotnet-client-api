using MarkLogic.Client.Tests.DataServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests.DataServices
{
    public class BasicTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public BasicTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Fact]
        public async void TestReturnNone()
        {
            await BasicTestsService.Create(DbClient).returnNone();
        }

        public static IEnumerable<object[]> TestReturnMultipleAtomicData()
        {
            return new[]
            {
                new object[] { "", 1234, DateTime.Now.AsISO8601() },
                new object[] { "the quick brown fox", 1234, DateTime.Now.AsISO8601() }
            };
        }

        [Theory]
        [MemberData(nameof(TestReturnMultipleAtomicData))]
        public async void TestReturnMultipleAtomic(string value1, int value2, DateTime value3)
        {
            var response = await BasicTestsService.Create(DbClient).returnMultipleAtomic(value1, value2, value3);
            Output.WriteLine(response);
            var results = response.Split("\n");
            Assert.Equal(3, results.Length);
            Assert.Equal(value1, results[0]);
            Assert.Equal(value2.ToString(), results[1]);
            Assert.Equal(value3.ToISODateTime(), results[2]);
        }

        public static IEnumerable<object[]> TestReturnMultipleAtomicNullData()
        {
            return new[]
            {
                new object[] { null, 1234, DateTime.Now.AsISO8601() }
            };
        }

        [Theory]
        [MemberData(nameof(TestReturnMultipleAtomicNullData))]
        public async void TestReturnMultipleAtomicNull(string value1, int value2, DateTime value3)
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => BasicTestsService.Create(DbClient).returnMultipleAtomic(value1, value2, value3));
            Assert.Equal("value1", exception.ParamName);
        }

        [Theory]
        [InlineData(new[] { 1 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public async void TestReturnMultiValue(int[] values)
        {
            var results = await BasicTestsService.Create(DbClient).returnMultiValue(values);
            OutputResults(string.Join(",", values), string.Join(",", results));
            Assert.Equal(values, results);
        }

        [Theory]
        [InlineData(new int[0])]
        [InlineData(null)]
        public async void TestReturnMultiValueNull(int[] values)
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => BasicTestsService.Create(DbClient).returnMultiValue(values));
            Assert.Equal("values", exception.ParamName);
        }

        [Fact]
        public async void TestErrorDetailLog()
        {
            var exception = await Assert.ThrowsAsync<DataServiceRequestException>(() => BasicTestsService.Create(DbClient).errorDetailLog());
            Assert.Equal(500, exception.StatusCode); // Internal Server Error
            Assert.Equal("Deliberate error", exception.MessageDetailTitle);
        }

        [Fact]
        public async void TestSession()
        {
            var service = BasicTestsService.Create(DbClient);

            var entityName = "Master Entity Name 1";
            var itemName = "Item Name 1";
            var session = service.NewSession();
            var id = await service.insertMaster(entityName, session);
            var result = await service.insertDetail(id, itemName, session);

            Assert.NotNull(result);
            Assert.Equal(id, result.Value<string>("id"));
            Assert.Equal(entityName, result.Value<string>("name"));
            Assert.Equal(itemName, result.SelectToken("items[0].itemName").Value<string>());
        }
    }
}
