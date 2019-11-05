using AppSys.Utility.Logging;
using Microsoft.Extensions.Logging;

namespace AppSys.Framework
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggerFactory RegisterLoggerFactory(this ILoggerFactory loggerFactory, string configPath = "Config/log4net.config")
        {
            return loggerFactory.AddLog4Net(configPath);
        }
    }
}