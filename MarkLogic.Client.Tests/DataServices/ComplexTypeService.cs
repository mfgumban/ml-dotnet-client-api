using MarkLogic.Client.DataService;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MarkLogic.Client.Tests.DataServices
{
    public class ComplexTypeService : DataServiceBase
    {
        protected ComplexTypeService(IDatabaseClient dbClient) : base(dbClient, "/test/complex/")
        {
        }

        public static ComplexTypeService Create(IDatabaseClient dbClient)
        {
            return new ComplexTypeService(dbClient);
        }

        public Task<JArray> ReturnArray(JArray value)
        {
            return CreateRequest("returnArray.xqy")
                .WithParameters(
                    new SingleParameter<JArray>("value", false, value, Marshal.JsonArray))
                .RequestSingle<JArray>(false, Unmarshal.JsonArray);
        }

        public Task<JObject> ReturnObject(JObject value)
        {
            return CreateRequest("returnObject.xqy")
                .WithParameters(
                    new SingleParameter<JObject>("value", false, value, Marshal.JsonObject))
                .RequestSingle<JObject>(false, Unmarshal.JsonObject);
        }

        public Task<Stream> ReturnBinary(Stream value)
        {
            return CreateRequest("returnBinary.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsBinary))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        public Task<Stream> ReturnTextDoc(Stream value)
        {
            return CreateRequest("returnTextDoc.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsText))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        public Task<Stream> ReturnJsonDocFromStream(Stream value)
        {
            return CreateRequest("returnJsonDoc.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        public Task<JObject> ReturnJsonDoc(JObject value)
        {
            return CreateRequest("returnJsonDoc.xqy")
                .WithParameters(
                    new SingleParameter<JObject>("value", false, value, Marshal.JsonObject))
                .RequestSingle<JObject>(false, Unmarshal.JsonObject);
        }

        public Task<Stream> ReturnXmlDocFromStream(Stream value)
        {
            return CreateRequest("returnXmlDoc.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsXml))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        public Task<XmlDocument> ReturnXmlDoc(XmlDocument value)
        {
            return CreateRequest("returnXmlDoc.xqy")
                .WithParameters(
                    new SingleParameter<XmlDocument>("value", false, value, Marshal.XmlDocument))
                .RequestSingle<XmlDocument>(false, Unmarshal.XmlDocument);
        }

        public Task<XDocument> ReturnXDoc(XDocument value)
        {
            return CreateRequest("returnXmlDoc.xqy")
                .WithParameters(
                    new SingleParameter<XDocument>("value", false, value, Marshal.XDocument))
                .RequestSingle<XDocument>(false, Unmarshal.XDocument);
        }
    }
}
