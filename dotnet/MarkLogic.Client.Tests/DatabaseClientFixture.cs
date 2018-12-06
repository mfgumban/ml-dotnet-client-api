using System;
using System.Net;

namespace MarkLogic.Client.Tests
{
    public class DatabaseClientFixture : IDisposable
    {
        private static class ConfigKey
        {
            public const string Host = "marklogic:host";
            public const string Port = "marklogic:port";
            public const string Username = "marklogic:username";
            public const string Password = "marklogic:password";
        }

        public DatabaseClientFixture()
        {
            DbClient = DatabaseClientFactory.Create(
                UriScheme.Http,
                Configuration.Instance.Get(ConfigKey.Host),
                Configuration.Instance.GetInt(ConfigKey.Port),
                new NetworkCredential(
                    Configuration.Instance.Get(ConfigKey.Username),
                    Configuration.Instance.Get(ConfigKey.Password),
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