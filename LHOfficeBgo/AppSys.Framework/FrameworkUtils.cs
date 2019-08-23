using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AppSys.Framework
{
    public class FrameworkUtils
    {
        public static readonly FrameworkUtils Instance = new FrameworkUtils();

        private FrameworkUtils() { }

        public IServiceProvider ServiceProvider { get; internal set; }


        public ILoggerFactory LoggerFactory { get; internal set; }


        public IConfiguration Configuration { get; internal set; }
    }
}
