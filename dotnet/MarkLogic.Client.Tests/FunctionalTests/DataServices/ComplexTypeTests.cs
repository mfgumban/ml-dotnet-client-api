using MarkLogic.Client.Tests.DataServices;
using Newtonsoft.Json.Linq;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests.DataServices
{
    public class ComplexTypeTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public ComplexTypeTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        private void OutputResults<T>(T value, T result)
        {
            Output.WriteLine("Value: {0} Return: {1}", value, result);
        }

        [Fact]
        public async void TestReturnArray()
        {
            var value = JArray.Parse("[\"the\", \"quick\", \"brown\", \"fox\", 1, 2, 3]");
            var result = await ComplexTypeTestsService.Create(DbClient).returnArray(value);
            Output.WriteLine(result.ToString());

            Assert.True(JToken.DeepEquals(value, result));
        }

        [Fact]
        public async void TestReturnObject()
        {
            var value = JObject.Parse("{ \"array\": [\"the\", \"quick\", \"brown\", \"fox\", 1, 2, 3], \"object\": { \"key\": \"k1\", \"value\": 1234 } }");
            var result = await ComplexTypeTestsService.Create(DbClient).returnObject(value);
            Output.WriteLine(result.ToString());

            Assert.True(JToken.DeepEquals(value, result));
        }
    }
}
