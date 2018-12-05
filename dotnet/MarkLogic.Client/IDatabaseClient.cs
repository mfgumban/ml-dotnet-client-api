using System;
using System.Net;
using System.Threading.Tasks;

namespace MarkLogic.Client
{
    public enum UriScheme
    {
        Http,
        Https
    }

    public enum AuthenticationType
    {
        Basic,
        Digest
    }

    public interface IDatabaseClient : IDisposable
    {
        IDataServiceRequest CreateDataServiceRequest(string servicePath, string moduleName);
    }
}