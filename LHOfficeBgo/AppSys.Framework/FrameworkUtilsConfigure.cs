using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AppSys.Framework
{
    public static class FrameworkUtilsConfigure
    {

        public static FrameworkUtils Configure(IServiceProvider serviceProvider, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            FrameworkUtils.Instance.Configuration = configuration;
            FrameworkUtils.Instance.ServiceProvider = serviceProvider;
            FrameworkUtils.Instance.LoggerFactory = loggerFactory;
            return FrameworkUtils.Instance;
        }
    }
}
