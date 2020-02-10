using System;

namespace MarkLogic.Client.Http
{
    public class HttpDatabaseClientException : Exception
    {
        public HttpDatabaseClientException(Uri dbClientUri, string message, Exception innerException = null)
            : base(message, innerException)
        {
            Uri = dbClientUri;
        }

        public Uri Uri { get; private set; }

        public static HttpDatabaseClientException CreateFromClient(HttpDatabaseClient dbClient, Exception innerException)
        {
            var uri = dbClient.Http.BaseAddress;
            var msg = $"Encountered {innerException.GetType().FullName} for connection {uri.AbsoluteUri} with message: {innerException.Message}";
            return new HttpDatabaseClientException(dbClient.Http.BaseAddress, msg, innerException);
        }
    }
}



