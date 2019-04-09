using System;
using System.Net.Http;

namespace MarkLogic.Client.Http
{
    public class HttpDatabaseClient : IDatabaseClient
    {
        internal HttpDatabaseClient(HttpClient httpClient)
        {
            Http = httpClient ?? throw new ArgumentNullException("httpClient");
        }

        internal HttpClient Http { get; }

        public IDataServiceRequest CreateDataServiceRequest(string servicePath, string moduleName)
        {
            return new HttpDataServiceRequest(this, servicePath, moduleName);
        }

        public ISessionState CreateSession()
        {
            return new HttpSessionState();
        }

        public void Dispose()
        {
            Http.Dispose();
        }
    }
}