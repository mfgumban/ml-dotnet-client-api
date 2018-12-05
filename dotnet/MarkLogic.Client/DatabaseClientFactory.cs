using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using MarkLogic.Client.Http;

namespace MarkLogic.Client
{
    public class DatabaseClientFactory
    {
        private static CredentialCache _credentialCache = new CredentialCache();

        private static HttpClient CreateHttpClient(UriScheme scheme, string host, int port, NetworkCredential credentials, AuthenticationType authType)
        {
            var uriBuilder = new UriBuilder()
            {
                Host = host,
                Port = port,
                Scheme = scheme == UriScheme.Https ? Uri.UriSchemeHttps : Uri.UriSchemeHttp
            };
            var clientHandler = new HttpClientHandler() { Credentials = _credentialCache, PreAuthenticate = true };
            var httpClient = new HttpClient(clientHandler) { BaseAddress = uriBuilder.Uri };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            var strAuthType = authType == AuthenticationType.Basic ? "Basic" : "Digest";
            var existingCredentials = _credentialCache.GetCredential(uriBuilder.Uri, strAuthType);
            if (existingCredentials != null)
            {
                _credentialCache.Remove(uriBuilder.Uri, strAuthType);
            }
            _credentialCache.Add(uriBuilder.Uri, strAuthType, credentials);

            return httpClient;
        }

         public static IDatabaseClient Create(UriScheme uriScheme, string host, int port, NetworkCredential credentials, AuthenticationType authType)
         {
             var httpClient = CreateHttpClient(uriScheme, host, port, credentials, authType);
             return new HttpDatabaseClient(httpClient);
         }
    }
}