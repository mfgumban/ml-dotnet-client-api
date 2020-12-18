using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MarkLogic.Client.Tests.DataServices
{
    public class ComplexTypeTheories
    {
        private static object[] TestValue<T>(string value, bool asStream, Func<string, T> map)
        {
            if (value == null)
                return new object[] { null };
            else if (asStream)
                return new object[] { new MemoryStream(Encoding.Default.GetBytes(value)) };
            else
                return new object[] { map(value) };
        }

        private static readonly string[] JsonArrayTestData = new[]
        {
            "[\"the\", \"quick\", \"brown\", \"fox\", 1, 2, 3]",
            "[]",
            "[\"single value\"]",
            "[0, 1, [10, 11]]",
            null
        };

        public static IEnumerable<object[]> JsonArray(bool asStream)
        {
            return JsonArrayTestData.Select(value => TestValue(value, asStream, v => JArray.Parse(v)));
        }

        private static readonly string[] JsonObjectTestData = new[]
        {
            "{ \"array\": [\"the\", \"quick\", \"brown\", \"fox\", 1, 2, 3], \"object\": { \"key\": \"k1\", \"value\": 1234 } }",
            "{}",
            "{ \"single\": \"value\" }",
            null
        };

        public static IEnumerable<object[]> JsonObject(bool asStream)
        {           
            return JsonObjectTestData.Select(value => TestValue(value, asStream, v => JObject.Parse(v)));
        }

        private static readonly string[] XmlTestData = new[]
        {
            @"<?xml version=""1.0"" encoding=""UTF-8""?>
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
            </shiporder>".Trim(),
            @"<foo>
                <bar>XML without a document node.</bar>
            </foo>".Trim(),
            null
        };

        public static IEnumerable<object[]> XmlDoc(bool asStream)
        {
            return XmlTestData.Select(value => TestValue(value, asStream, v => 
            {
                if (v == null)
                    return null;
                var doc = new XmlDocument();
                doc.LoadXml(v);
                return doc;
            }));
        }

        public static IEnumerable<object[]> XDoc(bool asStream)
        {
            return XmlTestData.Select(value => TestValue(value, asStream, v => XDocument.Parse(v)));
        }

        private static readonly string[] TextTestData = new[]
        {
            "The quick brown fox jumped over the lazy dog.",
            null
        };

        public static IEnumerable<object[]> TextDoc(bool asStream)
        {
            return TextTestData.Select(value => TestValue(value, asStream, v => v));
        }
    }
}
