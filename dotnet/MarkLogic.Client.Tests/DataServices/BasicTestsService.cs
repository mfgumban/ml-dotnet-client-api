using MarkLogic.Client.DataService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class BasicTestsService : DataServiceBase
    {
        protected BasicTestsService(IDatabaseClient dbClient) : base(dbClient, "/test/")
        {
        }

        public static BasicTestsService Create(IDatabaseClient dbClient)
        {
            return new BasicTestsService(dbClient);
        }

        public Task<string> returnMultipleAtomic(string value1, int value2, DateTime value3)
        {
            return CreateRequest("returnMultipleAtomic.xqy")
                .WithParameters(
                    new SingleParameter<string>("value1", false, value1, Marshal.String),
                    new SingleParameter<int>("value2", false, value2, Marshal.Integer),
                    new SingleParameter<DateTime>("value3", false, value3, Marshal.DateTime))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        public Task<IEnumerable<int>> returnMultiValue(IEnumerable<int> values)
        {
            return CreateRequest("returnMultiValue.xqy")
                .WithParameters(
                    new MultipleParameter<int>("values", false, values, Marshal.Integer))
                .RequestMultiple<int>(false, Unmarshal.Integer);
        }

        public Task returnNone()
        {
            return CreateRequest("returnNone.xqy")
                .RequestNone();
        }

        public Task errorDetailLog()
        {
            return CreateRequest("errorDetailLog.xqy")
                .RequestNone();
        }
    }
}
