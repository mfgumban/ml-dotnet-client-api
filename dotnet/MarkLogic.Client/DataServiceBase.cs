using System;

namespace MarkLogic.Client
{
    public abstract class DataServiceBase
    {
        protected DataServiceBase(IDatabaseClient dbClient, string servicePath)
        {
            DbClient = dbClient;
            ServicePath = servicePath;
        }

        protected IDatabaseClient DbClient { get; private set; }

        public string ServicePath { get; private set; }

        protected IDataServiceRequest CreateRequest(string moduleName)
        {
            return DbClient.CreateDataServiceRequest(ServicePath, moduleName);
        }
    }
}