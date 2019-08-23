using Microsoft.Extensions.Logging;

namespace AppSys.Framework
{
    public class IocManager
    {
        private static readonly ILogger logger = LogHelper.CreateLogger<IocManager>();

        /// <summary>
        ///     获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>(string name = null)
        {
            try
            {
                var serviceProvider = FrameworkUtils.Instance.ServiceProvider;
                return (T)serviceProvider.GetService(typeof(T));
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}