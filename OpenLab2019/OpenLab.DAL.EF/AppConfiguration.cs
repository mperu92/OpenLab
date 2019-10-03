using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace OpenLab.DAL.EF
{
    public interface IAppConfiguration
    {
        string ConnectionString { get; }
        string SoftwareVersion { get; }
        string EmailKey { get; }
    }

    public class AppConfiguration : IAppConfiguration
    {
        public readonly string _connectionString;
        public readonly string _swversion;
        public readonly string _emailKey;

        public AppConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            IConfigurationRoot root = configurationBuilder.Build();
            IConfigurationSection AppConfiguration = root.GetSection("AppConfiguration");

            _connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            _swversion = AppConfiguration["swversion"];
            _emailKey = AppConfiguration["pe_key"];
        }

        public string ConnectionString { get => _connectionString; }
        public string SoftwareVersion { get => _swversion; }
        public string EmailKey { get => _emailKey; }
    }
}
