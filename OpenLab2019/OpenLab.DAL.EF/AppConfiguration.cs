using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace OpenLab.DAL.EF
{
    public interface IAppConfiguration
    {
        string ConnectionString { get; }
        string SoftwareVersion { get; }
        string SendGridApiKey { get; }
    }

    public class AppConfiguration : IAppConfiguration
    {
        public readonly string _connectionString;
        public readonly string _swversion;
        public readonly string _sendgirdApiKey;

        public AppConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            IConfigurationRoot root = configurationBuilder.Build();
            IConfigurationSection AppConfiguration = root.GetSection("AppConfiguration");

            _connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            _swversion = AppConfiguration["swversion"];
            _sendgirdApiKey = AppConfiguration["SENDGRID_API_KEY"];
        }

        public string ConnectionString { get => _connectionString; }
        public string SoftwareVersion { get => _swversion; }
        public string SendGridApiKey { get => _sendgirdApiKey; }
    }
}
