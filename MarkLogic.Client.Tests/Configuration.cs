using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MarkLogic.Client.Tests
{
    public sealed class Configuration
    {
        private static Lazy<Configuration> _instance = new Lazy<Configuration>(() => new Configuration());
        private readonly IConfiguration _config;

        private Configuration()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.default.json", false) // base settings; used for local testing (i.e. "dotnet test")
                .AddJsonFile("settings.json", true) // setting overrides 
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

        public bool GetBool(string key)
        {
            var value = _config[key];
            if (value == null)
            {
                throw new InvalidOperationException($"Missing configuration value for {key}.");
            }
            return value.ToLower() == "true";
        }

        private static class ConfigKey
        {
            public const string Host = "marklogic:host";
            public const string Port = "marklogic:port";
            public const string Username = "marklogic:username";
            public const string Password = "marklogic:password";
            public const string UseSSL = "marklogic:ssl";
        }

        public string MLHost => Get(ConfigKey.Host);

        public int MLPort => GetInt(ConfigKey.Port);

        public string MLUsername => Get(ConfigKey.Username);

        public string MLPassword => Get(ConfigKey.Password);

        public bool UseSSL => GetBool(ConfigKey.UseSSL);
    }
}
