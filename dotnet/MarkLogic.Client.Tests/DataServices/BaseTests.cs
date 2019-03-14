using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.DataServices
{
    public class BaseTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public BaseTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Fact]
        public async void ReturnNone()
        {
            await BaseService.Create(DbClient).ReturnNone();
        }

        public static IEnumerable<object[]> MultipleAtomicData()
        {
            return new[]
            {
                new object[] { "", 1234, DateTime.Now.AsISO8601() },
                new object[] { "the quick brown fox", 1234, DateTime.Now.AsISO8601() }
            };
        }

        [Theory]
        [MemberData(nameof(MultipleAtomicData))]
        public async void MultipleAtomic(string value1, int value2, DateTime value3)
        {
            var response = await BaseService.Create(DbClient).ReturnMultipleAtomic(value1, value2, value3);
            Output.WriteLine(response);
            var results = response.Split("\n");
            Assert.Equal(3, results.Length);
            Assert.Equal(value1, results[0]);
            Assert.Equal(value2.ToString(), results[1]);
            Assert.Equal(value3.ToISODateTime(), results[2]);
        }

        public static IEnumerable<object[]> MultipleAtomicNullData()
        {
            return new[]
            {
                new object[] { null, 1234, DateTime.Now.AsISO8601() }
            };
        }

        [Theory]
        [MemberData(nameof(MultipleAtomicNullData))]
        public async void MultiAtomicException(string value1, int value2, DateTime value3)
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => BaseService.Create(DbClient).ReturnMultipleAtomic(value1, value2, value3));
            Assert.Equal("value1", exception.ParamName);
        }

        [Theory]
        [InlineData(new[] { 1 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public async void MultiValue(int[] values)
        {
            var results = await BaseService.Create(DbClient).ReturnMultiValue(values);
            OutputResults(string.Join(",", values), string.Join(",", results));
            Assert.Equal(values, results);
        }

        [Theory]
        [InlineData(new int[0])]
        [InlineData(null)]
        public async void MultiValueException(int[] values)
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => BaseService.Create(DbClient).ReturnMultiValue(values));
            Assert.Equal("values", exception.ParamName);
        }

        [Fact]
        public async void ErrorDetailLog()
        {
            var exception = await Assert.ThrowsAsync<DataServiceRequestException>(() => BaseService.Create(DbClient).ErrorDetailLog());
            Assert.Equal(500, exception.StatusCode); // Internal Server Error
            Assert.Equal("Deliberate error", exception.MessageDetailTitle);
        }

        [Fact]
        public async void Session()
        {
            var service = BaseService.Create(DbClient);

            var entityName = "Master Entity Name 1";
            var itemName = "Item Name 1";
            var session = service.NewSession();
            var id = await service.InsertMaster(entityName, session);
            var result = await service.InsertDetail(id, itemName, session);

            Assert.NotNull(result);
            Assert.Equal(id, result.Value<string>("id"));
            Assert.Equal(entityName, result.Value<string>("name"));
            Assert.Equal(itemName, result.SelectToken("items[0].itemName").Value<string>());
        }
    }
}
