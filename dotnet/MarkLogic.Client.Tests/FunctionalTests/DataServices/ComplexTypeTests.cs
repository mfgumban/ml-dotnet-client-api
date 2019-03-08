using MarkLogic.Client.Tests.DataServices;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
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

        [Fact]
        public async void TestReturnBinary()
        {
            var binary = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarkLogic.Client.Tests.Resources.marklogic-logo-social.jpg");

            // copy bytes before it gets disposed by the service call
            var input = new MemoryStream();
            await binary.CopyToAsync(input);
            var inputBytes = input.ToArray();
            input.Position = 0;

            var result = await ComplexTypeTestsService.Create(DbClient).returnBinary(input);

            Assert.NotNull(result);

            // get bytes to compare
            var resultCopy = new MemoryStream();
            await result.CopyToAsync(resultCopy);
            var resultBytes = resultCopy.ToArray();
            resultCopy.Dispose();

            OutputResults(inputBytes.Length, resultBytes.Length);
            Assert.Equal(inputBytes.Length, resultBytes.Length);
            Assert.Equal(inputBytes, resultBytes);

            input.Dispose();
            result.Dispose();
        }

        [Fact]
        public async void TestReturnTextDoc()
        {
            var inputData = "The quick brown fox jumped over the lazy dog beside the riverbank.";
            var input = new MemoryStream();
            var inputWriter = new StreamWriter(input);
            await inputWriter.WriteAsync(inputData);
            inputWriter.Flush();
            input.Position = 0;

            var result = await ComplexTypeTestsService.Create(DbClient).returnTextDoc(input);

            Assert.NotNull(result);

            var resultReader = new StreamReader(result);
            var resultData = await resultReader.ReadToEndAsync();
            OutputResults(inputData, resultData);
            Assert.Equal(inputData, resultData);

            inputWriter.Dispose();
            resultReader.Dispose();
            input.Dispose();
            result.Dispose();
        }
    }
}
