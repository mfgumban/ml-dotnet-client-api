using MarkLogic.Client.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            var date = new DateTime(2019, 3, 21, 10, 14, 44, 930);
            return new[]
            {
                new object[] { "", 1234, date },
                new object[] { "the quick brown fox", 1234, date }
            };
        }

        [Theory]
        [MemberData(nameof(MultipleAtomicData))]
        public async void MultipleAtomic(string value1, int value2, DateTime value3)
        {
            var response = await BaseService.Create(DbClient).ReturnMultipleAtomic(value1, value2, value3);
            OutputResults(string.Join("\n", value1, value2, value3), response);
            var results = response.Split("\n");
            Assert.Equal(3, results.Length);
            Assert.Equal(value1, results[0]);
            Assert.Equal(value2, Convert.ToInt32(results[1]));
            Assert.Equal(value3, Convert.ToDateTime(results[2]));
        }

        public static IEnumerable<object[]> MultipleAtomicNullData()
        {
            var date = new DateTime(2019, 3, 21, 10, 14, 44, 930);
            return new[]
            {
                new object[] { null, 1234, date }
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
            var exception = await Assert.ThrowsAsync<HttpDataServiceRequestException>(() => BaseService.Create(DbClient).ErrorDetailLog());
            Assert.Equal(500, exception.StatusCode); // Internal Server Error
            Assert.Equal("Deliberate error", exception.MessageDetailTitle);
        }

        public static IEnumerable<object[]> OptionalParamsTestData()
        {
            var values = new object[] 
            {
                "some string value.",
                new[] { 0, 1, -1 },
                "{\"enterprise\": \"defiant\"}",
                "{\"voyager\": \"excelsior\"}"
            };

            var pidx = Enumerable.Range(0, values.Length).ToArray();
            return Enumerable
                .Range(0, 1 << (pidx.Length))
                .Select(idx => pidx.Where((v, i) => (idx & (1 << i)) != 0))
                .Select(mask => values.Select((v, i) => mask.Contains(i) ? v : null))
                .Select(r => new object[] { r.Count(v => v == null) }.Concat(r).ToArray());
        }

        [Theory]
        [MemberData(nameof(OptionalParamsTestData))]
        public async void OptionalParams(int totalNulls, string a, IEnumerable<int> b, string c, string d)
        {
            var obj = c != null ? JObject.Parse(c) : null;
            var stream = d != null ? new MemoryStream(Encoding.Default.GetBytes(d)) : null;
            var results = await BaseService.Create(DbClient).OptionalParams(a, b, obj, stream);
            Assert.Equal(totalNulls, results);
            stream?.Dispose();
        }
    }
}