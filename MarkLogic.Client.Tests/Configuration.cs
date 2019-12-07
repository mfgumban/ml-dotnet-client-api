using Microsoft.Extensions.Configuration;
using System;

namespace MarkLogic.Client.Tests
{
    public sealed class Configuration
    {
        private static Lazy<Configuration> _instance = new Lazy<Configuration>(() => new Configuration());
        private readonly IConfiguration _config;

        private Configuration()
        {
            _config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
        }

        public static Configuration Instance => _instance.Value;

        public string Get(string key, bool allowNull = true)
        {
            var value = _config[key];
            if (!allowNull && string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Missing configuration for {key}.");
            }
            return value;
        }

        public int GetInt(string key)
        {
            if (!int.TryParse(_config[key], out int value))
            {
                throw new InvalidOperationException($"Missing configuration or non-int value for {key}.");
            }
            return value;
        }

        private static class ConfigKey
        {
            public const string Host = "MARKLOGIC_HOST";
            public const string Port = "MARKLOGIC_PORT";
            public const string Username = "MARKLOGIC_USERNAME";
            public const string Password = "MARKLOGIC_PASSWORD";
            public const string AuthType = "MARKLOGIC_AUTH";
        }

        public string MLHost => Get(ConfigKey.Host);

        public int MLPort => GetInt(ConfigKey.Port);

        public string MLUsername => Get(ConfigKey.Username);

        public string MLPassword => Get(ConfigKey.Password);

        public string MLAuthType => Get(ConfigKey.AuthType);

        public bool UseSSL => MLAuthType == "SSL";
    }
}
