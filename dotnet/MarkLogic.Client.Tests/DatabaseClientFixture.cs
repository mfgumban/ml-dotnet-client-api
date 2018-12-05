using System;
using System.Net;
using MarkLogic.Client;

namespace MarkLogic.Client.Tests
{
    public class DatabaseClientFixture : IDisposable
    {
        public DatabaseClientFixture()
        {
            DbClient = DatabaseClientFactory.Create(
                UriScheme.Http, 
                //"192.168.1.103",
                "localhost", 
                8019,
                new NetworkCredential("admin", "admin", "public"),
                AuthenticationType.Digest);
        }

        public IDatabaseClient DbClient { get; private set; }

        public void Dispose()
        {
            DbClient.Dispose();
        }
    }
}