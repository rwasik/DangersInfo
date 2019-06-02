using Microsoft.Extensions.DependencyInjection;
using WarsawOpenData.Proxy.Services;
using WarsawOpenData.Proxy.Utils;

namespace WarsawOpenData.Proxy.ModuleConfiguration
{
    public static class WarsawOpenDataProxyModule
    {
        public static void ConfigureWarsawOpenDataProxyServices(this IServiceCollection services)
        {
            services.AddSingleton<IWarsawOpenDataService, WarsawOpenDataService>();
            services.AddSingleton<IRemoteClient, RemoteClient>();
        }
    }
}
