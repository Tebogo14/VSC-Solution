using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace VSC.Entityframeworkcore.Configuration
{
    public static class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> _configurationCache;

        static AppConfigurations()
        {
            _configurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfiguration Get(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var cache = path + "#" + environmentName + "#" + addUserSecrets;
            return _configurationCache.GetOrAdd(
                cache, _ => BuildConfiguration(path));
        }

        public static IConfigurationRoot BuildConfiguration(string path)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(path)
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}