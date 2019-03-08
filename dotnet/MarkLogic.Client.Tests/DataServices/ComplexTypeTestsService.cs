using MarkLogic.Client.DataService;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class ComplexTypeTestsService : DataServiceBase
    {
        protected ComplexTypeTestsService(IDatabaseClient dbClient) : base(dbClient, "/test/complex/")
        {
        }

        public static ComplexTypeTestsService Create(IDatabaseClient dbClient)
        {
            return new ComplexTypeTestsService(dbClient);
        }

        public Task<JArray> returnArray(JArray value)
        {
            return CreateRequest("returnArray.xqy")
                .WithParameters(
                    new SingleParameter<JArray>("value", false, value, Marshal.JsonArray))
                .RequestSingle<JArray>(false, Unmarshal.JsonArray);
        }

        public Task<JObject> returnObject(JObject value)
        {
            return CreateRequest("returnObject.xqy")
                .WithParameters(
                    new SingleParameter<JObject>("value", false, value, Marshal.JsonObject))
                .RequestSingle<JObject>(false, Unmarshal.JsonObject);
        }

        public Task<Stream> returnBinary(Stream value)
        {
            return CreateRequest("returnBinary.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsBinary))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        public Task<Stream> returnTextDoc(Stream value)
        {
            return CreateRequest("returnTextDoc.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsText))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        public Task<Stream> returnJsonDoc(Stream value)
        {
            return CreateRequest("returnJsonDoc.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        public Task<Stream> returnXmlDoc(Stream value)
        {
            return CreateRequest("returnXmlDoc.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("value", false, value, Marshal.StreamAsXml))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }
    }
}
