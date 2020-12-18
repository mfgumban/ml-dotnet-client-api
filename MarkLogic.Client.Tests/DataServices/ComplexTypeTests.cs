using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.DataServices
{
    public class ComplexTypeTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public ComplexTypeTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        private static string GetStreamContent(Stream stream)
        {
            if (stream == null)
                return null;
            using (var reader = new StreamReader(stream, leaveOpen: true))
            {
                var content = reader.ReadToEnd();
                stream.Position = 0;
                return content;
            }
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.JsonArray), parameters: false, MemberType = typeof(ComplexTypeTheories))]
        public async void JsonArray(JArray value)
        {
            var result = await ComplexTypeService.Create(DbClient).ReturnArray(value);
            Assert.True(value != null ? JToken.DeepEquals(value, result) : result == null);
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.JsonObject), parameters: false, MemberType = typeof(ComplexTypeTheories))]
        public async void JsonObject(JObject value)
        {
            var result = await ComplexTypeService.Create(DbClient).ReturnObject(value);
            Assert.True(value != null ? JToken.DeepEquals(value, result) : result == null);
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.JsonObject), parameters: false, MemberType = typeof(ComplexTypeTheories))]
        public async void JsonDoc(JObject value)
        {
            var result = await ComplexTypeService.Create(DbClient).ReturnJsonDoc(value);
            Assert.True(value != null ? JToken.DeepEquals(value, result) : result == null);
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.JsonObject), parameters: true, MemberType = typeof(ComplexTypeTheories))]
        public async void JsonDocFromStream(Stream value)
        {
            var rawValue = GetStreamContent(value);
            using (var result = await ComplexTypeService.Create(DbClient).ReturnJsonDocFromStream(value))
            {
                var resultReader = new StreamReader(result);
                var resultData = await resultReader.ReadToEndAsync();
                Assert.True(value == null ? string.IsNullOrEmpty(resultData) : JToken.DeepEquals(JObject.Parse(rawValue), JObject.Parse(resultData)));
            }
            value?.Dispose();
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.TextDoc), parameters: true, MemberType = typeof(ComplexTypeTheories))]
        public async void TextDocFromStream(Stream value)
        {
            var rawValue = GetStreamContent(value);
            using (var result = await ComplexTypeService.Create(DbClient).ReturnTextDoc(value))
            {
                var resultReader = new StreamReader(result);
                var resultData = await resultReader.ReadToEndAsync();
                Assert.True(value == null ? string.IsNullOrEmpty(resultData) : resultData == rawValue);
            }
            value?.Dispose();
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.XmlDoc), parameters: false, MemberType = typeof(ComplexTypeTheories))]
        public async void XmlDoc(XmlDocument value)
        {
            var result = await ComplexTypeService.Create(DbClient).ReturnXmlDoc(value);
            Assert.True(value != null ? XNode.DeepEquals(value.ToXDocument(), result.ToXDocument()) : result == null);
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.XmlDoc), parameters: true, MemberType = typeof(ComplexTypeTheories))]
        public async void XmlDocFromStream(Stream value)
        {
            var rawValue = GetStreamContent(value);
            using (var result = await ComplexTypeService.Create(DbClient).ReturnXmlDocFromStream(value))
            {
                var resultReader = new StreamReader(result);
                var resultData = await resultReader.ReadToEndAsync();
                Assert.True(value == null ? string.IsNullOrEmpty(resultData) : XNode.DeepEquals(XDocument.Parse(rawValue), XDocument.Parse(resultData)));
            }
            value?.Dispose();
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTheories.XDoc), parameters: false, MemberType = typeof(ComplexTypeTheories))]
        public async void XDoc(XDocument value)
        {
            var result = await ComplexTypeService.Create(DbClient).ReturnXDoc(value);
            Assert.True(XNode.DeepEquals(value, result));
        }

        [Fact]
        public async void Binary()
        {
            var binary = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarkLogic.Client.Tests.Resources.marklogic-logo-social.jpg");

            // copy bytes before it gets disposed by the service call
            var input = new MemoryStream();
            await binary.CopyToAsync(input);
            var inputBytes = input.ToArray();
            input.Position = 0;

            var result = await ComplexTypeService.Create(DbClient).ReturnBinary(input);

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
    }
}
