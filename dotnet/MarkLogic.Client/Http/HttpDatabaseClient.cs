using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarkLogic.Client.Http
{
    public class HttpDatabaseClient : IDatabaseClient
    {
        internal HttpDatabaseClient(HttpClient httpClient)
        {
            // Check.NotNull
            Http = httpClient;
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