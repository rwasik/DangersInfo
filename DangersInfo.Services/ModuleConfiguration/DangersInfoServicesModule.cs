using DangersInfo.Services.Mapping;
using DangersInfo.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DangersInfo.Services.ModuleConfiguration
{
    public static class DangersInfoServicesModule
    {
        public static void ConfigureDangersInfoServices(this IServiceCollection services)
        {
            services.AddScoped<IDangersInfoService, DangersInfoService>();
            services.AddSingleton<INotificationToReportedDangerMapper, NotificationToReportedDangerMapper>();
        }
    }
}
