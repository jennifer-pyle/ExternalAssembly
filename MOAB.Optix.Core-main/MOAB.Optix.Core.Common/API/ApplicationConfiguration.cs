using System.Reflection;
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;

namespace MOAB.Optix.Core.Common.API
{
    public static class ApplicationConfiguration
    {
        private static IConfigurationRoot _configuration;
        static ApplicationConfiguration()
        {
            //var path = "D:\\VM_Shared_Drive\\SoftwareDevTools\\OptixAsyncNetLogic\\OptixAsyncNetLogic\\ProjectFiles\\MOAB.Optix.Core";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public static string GetSetting(string key)
        {
            return _configuration[key];
            return "";
        }
    }
}
