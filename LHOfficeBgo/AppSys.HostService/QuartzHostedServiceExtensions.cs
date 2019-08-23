using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz.Spi;

namespace AppSys.HostService
{
    public static class QuartzHostedServiceExtensions
    {
        public static IServiceCollection AddQuartzHostedService(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IJobFactory, QuartzJonFactory>();
            return serviceCollection;
        }
    }
}
