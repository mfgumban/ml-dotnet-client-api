using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarkLogic.Client.Http
{
    public class HttpDatabaseClient : IDatabaseClient
    {
        private readonly HttpClient _http;

        internal HttpDatabaseClient(HttpClient httpClient)
        {
            // Check.NotNull
            _http = httpClient;
        }

        internal HttpClient Http => _http;

        public IDataServiceRequest CreateDataServiceRequest(string servicePath, string moduleName)
        {
            return new HttpDataServiceRequest(this, servicePath, moduleName);
        }

        public void Dispose()
        {
            _http.Dispose();
        }
    }
}