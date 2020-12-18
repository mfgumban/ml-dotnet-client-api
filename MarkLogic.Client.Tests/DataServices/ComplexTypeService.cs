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
            return CreateRequest("returnArray.sjs")
                .WithParameters(
                    new SingleParameter<JArray>("value", true, value, Marshal.JsonArray))
                .RequestSingle<JArray>(true, Unmarshal.JsonArray);
        }

        public Task<JObject> ReturnObject(JObject value)
        {
            return CreateRequest("returnObject.sjs")
                .WithParameters(
                    new SingleParameter<JObject>("value", true, value, Marshal.JsonObject))
                .RequestSingle<JObject>(true, Unmarshal.JsonObject);
        }

        public Task<Stream> ReturnBinary(Stream value)
        {
            return CreateRequest("returnBinary.sjs")
                .WithParameters(
                    new SingleParameter<Stream>("value", true, value, Marshal.StreamAsBinary))
                .RequestSingle<Stream>(true, Unmarshal.Stream);
        }

        public Task<Stream> ReturnTextDoc(Stream value)
        {
            return CreateRequest("returnTextDoc.sjs")
                .WithParameters(
                    new SingleParameter<Stream>("value", true, value, Marshal.StreamAsText))
                .RequestSingle<Stream>(true, Unmarshal.Stream);
        }

        public Task<Stream> ReturnJsonDocFromStream(Stream value)
        {
            return CreateRequest("returnJsonDoc.sjs")
                .WithParameters(
                    new SingleParameter<Stream>("value", true, value, Marshal.StreamAsJson))
                .RequestSingle<Stream>(true, Unmarshal.Stream);
        }

        public Task<JObject> ReturnJsonDoc(JObject value)
        {
            return CreateRequest("returnJsonDoc.sjs")
                .WithParameters(
                    new SingleParameter<JObject>("value", true, value, Marshal.JsonObject))
                .RequestSingle<JObject>(true, Unmarshal.JsonObject);
        }

        public Task<XmlDocument> ReturnXmlDoc(XmlDocument value)
        {
            return CreateRequest("returnXmlDoc.sjs")
                .WithParameters(
                    new SingleParameter<XmlDocument>("value", true, value, Marshal.XmlDocument))
                .RequestSingle<XmlDocument>(true, Unmarshal.XmlDocument);
        }

        public Task<Stream> ReturnXmlDocFromStream(Stream value)
        {
            return CreateRequest("returnXmlDoc.sjs")
                .WithParameters(
                    new SingleParameter<Stream>("value", true, value, Marshal.StreamAsXml))
                .RequestSingle<Stream>(true, Unmarshal.Stream);
        }


        public Task<XDocument> ReturnXDoc(XDocument value)
        {
            return CreateRequest("returnXmlDoc.sjs")
                .WithParameters(
                    new SingleParameter<XDocument>("value", true, value, Marshal.XDocument))
                .RequestSingle<XDocument>(true, Unmarshal.XDocument);
        }
    }
}
