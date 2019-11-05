using System;
using Microsoft.Extensions.Logging;

namespace AppSys.Framework
{
    public class LogHelper
    {
        public static ILogger CreateLogger(string categoryName) => FrameworkUtils.Instance.LoggerFactory.CreateLogger(categoryName);

        public static ILogger CreateLogger(Type type) => FrameworkUtils.Instance.LoggerFactory.CreateLogger(type);

        public static ILogger CreateLogger<T>() => FrameworkUtils.Instance.LoggerFactory.CreateLogger<T>();
    }
}
