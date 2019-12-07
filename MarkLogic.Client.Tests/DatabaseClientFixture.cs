using System;
using System.Net;

namespace MarkLogic.Client.Tests
{
    public class DatabaseClientFixture : IDisposable
    {
        public DatabaseClientFixture()
        {
            DbClient = DatabaseClientFactory.Create(
                Configuration.Instance.UseSSL ? UriScheme.Https : UriScheme.Http,
                Configuration.Instance.MLHost,
                Configuration.Instance.MLPort,
                new NetworkCredential(
                    Configuration.Instance.MLUsername,
                    Configuration.Instance.MLPassword,
                    "public"),
                AuthenticationType.Digest);
        }

        public IDatabaseClient DbClient { get; private set; }

        public void Dispose()
        {
            DbClient.Dispose();
        }
    }
}