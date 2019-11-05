using AppSys.Utility.Extensions;
using Microsoft.Extensions.Configuration;

namespace AppSys.Framework.Config
{
    public static class ConfigManager
    {
        public static IConfiguration Configuration = FrameworkUtils.Instance.Configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            if (Configuration == null)
                Configuration = configuration;
        }

        /// <summary>
        /// 值类型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            string value = Configuration[key];
            if (!value.IsNullOrEmpty())
                return value;
            return "";
        }
    }
}
