using MarkLogic.Client.DataService;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class BaseService : DataServiceBase
    {
        protected BaseService(IDatabaseClient dbClient) : base(dbClient, "/test/")
        {
        }

        public static BaseService Create(IDatabaseClient dbClient)
        {
            return new BaseService(dbClient);
        }

        public ISessionState NewSession()
        {
            return DbClient.CreateSession();
        }

        public Task<string> ReturnMultipleAtomic(string value1, int value2, DateTime value3)
        {
            return CreateRequest("returnMultipleAtomic.xqy")
                .WithParameters(
                    new SingleParameter<string>("value1", false, value1, Marshal.String),
                    new SingleParameter<int>("value2", false, value2, Marshal.Integer),
                    new SingleParameter<DateTime>("value3", false, value3, Marshal.DateTime))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        public Task<IEnumerable<int>> ReturnMultiValue(IEnumerable<int> values)
        {
            return CreateRequest("returnMultiValue.xqy")
                .WithParameters(
                    new MultipleParameter<int>("values", false, values, Marshal.Integer))
                .RequestMultiple<int>(false, Unmarshal.Integer);
        }

        public Task ReturnNone()
        {
            return CreateRequest("returnNone.xqy")
                .RequestNone();
        }

        public Task ErrorDetailLog()
        {
            return CreateRequest("errorDetailLog.xqy")
                .RequestNone();
        }

        public Task<string> InsertMaster(string name, ISessionState session)
        {
            return CreateRequest("insertMaster.xqy")
                .WithSession(session, false)
                .WithParameters(
                    new SingleParameter<string>("name", false, name, Marshal.String))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        public Task<JObject> InsertDetail(string id, string itemName, ISessionState session)
        {
            return CreateRequest("insertDetail.xqy")
                .WithSession(session, false)
                .WithParameters(
                    new SingleParameter<string>("id", false, id, Marshal.String),
                    new SingleParameter<string>("itemName", false, itemName, Marshal.String))
                .RequestSingle<JObject>(false, Unmarshal.JsonObject);
        }
    }
}
