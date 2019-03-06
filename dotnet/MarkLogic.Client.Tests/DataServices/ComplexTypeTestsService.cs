using MarkLogic.Client.DataService;
using Newtonsoft.Json.Linq;
using System;
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
    }
}
