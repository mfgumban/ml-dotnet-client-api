using MarkLogic.Client.Tests.DataServices;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
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

        private static readonly string ValidJson = "{ \"array\": [\"the\", \"quick\", \"brown\", \"fox\", 1, 2, 3], \"object\": { \"key\": \"k1\", \"value\": 1234 } }";

        private static readonly string ValidXmlDocument = @"
            <?xml version=""1.0"" encoding=""UTF-8""?>
            <shiporder orderid=""889923"">
              <orderperson>John Smith</orderperson>
              <shipto>
                <name>Ola Nordmann</name>
                <address>Langgt 23</address>
                <city>4000 Stavanger</city>
                <country>Norway</country>
              </shipto>
              <item>
                <title>Empire Burlesque</title>
                <note>Special Edition</note>
                <quantity>1</quantity>
                <price>10.90</price>
              </item>
              <item>
                <title>Hide your heart</title>
                <quantity>1</quantity>
                <price>9.90</price>
              </item>
            </shiporder>".Trim();

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
            var value = JObject.Parse(ValidJson);
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

        [Fact]
        public async void TestReturnJsonDoc()
        {
            var value = JObject.Parse(ValidJson);
            var result = await ComplexTypeTestsService.Create(DbClient).returnJsonDoc(value);
            OutputResults(value.ToString(), result.ToString());

            Assert.True(JToken.DeepEquals(value, result));
        }

        [Fact]
        public async void TestReturnJsonDocFromStream()
        {
            var valueString = ValidJson;
            var value = new MemoryStream();
            var writer = new StreamWriter(value);
            writer.Write(valueString);
            writer.Flush();
            value.Position = 0;

            var result = await ComplexTypeTestsService.Create(DbClient).returnJsonDocFromStream(value);
            var reader = new StreamReader(result);
            var resultString = await reader.ReadToEndAsync();
            OutputResults(valueString, resultString);

            Assert.True(JToken.DeepEquals(JObject.Parse(valueString), JObject.Parse(resultString)));

            reader.Dispose();
            writer.Dispose();
            value.Dispose();
            result.Dispose();
        }

        [Fact]
        public async void TestReturnXmlDoc()
        {
            var value = new XmlDocument();
            value.LoadXml(ValidXmlDocument);
            var result = await ComplexTypeTestsService.Create(DbClient).returnXmlDoc(value);
            OutputResults(value.OuterXml, result.OuterXml);

            Assert.True(XNode.DeepEquals(value.ToXDocument(), result.ToXDocument()));
        }

        [Fact]
        public async void TestReturnXDoc()
        {
            var value = XDocument.Parse(ValidXmlDocument);
            var result = await ComplexTypeTestsService.Create(DbClient).returnXDoc(value);
            OutputResults(value.ToString(), result.ToString());

            Assert.True(XNode.DeepEquals(value, result));
        }

        [Fact]
        public async void TestReturnXmlDocFromStream()
        {
            var valueString = ValidXmlDocument;
            var value = new MemoryStream();
            var writer = new StreamWriter(value);
            writer.Write(valueString);
            writer.Flush();
            value.Position = 0;

            var result = await ComplexTypeTestsService.Create(DbClient).returnXmlDocFromStream(value);
            var reader = new StreamReader(result);
            var resultString = await reader.ReadToEndAsync();
            OutputResults(valueString, resultString);

            Assert.True(XNode.DeepEquals(XDocument.Parse(valueString), XDocument.Parse(resultString)));

            reader.Dispose();
            writer.Dispose();
            value.Dispose();
            result.Dispose();
        }
    }
}
