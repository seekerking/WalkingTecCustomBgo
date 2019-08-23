using Microsoft.Extensions.Logging;

namespace AppSys.Utility.Logging
{

    /// <summary>
    /// The log4net extensions class.
    /// </summary>
    public static class Log4NetExtensions
    {
        /// <summary>
        /// Adds the log4net.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="log4NetConfigFile">The log4net Config File.</param>
        /// <returns>The <see cref="ILoggerFactory"/>.</returns>
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile="Config/log4net.config")
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }
    
    }
}
