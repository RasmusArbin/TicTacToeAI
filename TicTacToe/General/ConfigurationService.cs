using System.IO;
using Microsoft.Extensions.Configuration;

namespace TicTacToe.General
{
    public static class ConfigurationService
    {
        public static IConfigurationRoot _configuration;
        public static string ConnectionString => _configuration.GetConnectionString("TicTacToeDatabase");
        static ConfigurationService()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
