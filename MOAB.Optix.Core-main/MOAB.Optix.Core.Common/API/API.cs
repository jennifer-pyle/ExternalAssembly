using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOAB.Optix.Core.Common.API
{
    public class API
    {
        private readonly string apiUrl;
        private readonly string configFilePath;
        public API()
        {
            apiUrl = ApplicationConfiguration.GetSetting("apiUrl");
            configFilePath = ApplicationConfiguration.GetSetting("configFilePath");
        }
    }
}
