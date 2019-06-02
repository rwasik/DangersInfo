using System.Collections.Generic;
using System.Threading.Tasks;
using DangersInfo.Configuration.Configs;
using Microsoft.Extensions.Options;
using WarsawOpenData.Proxy.Contracts;
using WarsawOpenData.Proxy.Utils;

namespace WarsawOpenData.Proxy.Services
{
    public class WarsawOpenDataService : IWarsawOpenDataService
    {
        private readonly IRemoteClient _remoteClient;
        private readonly WarsawOpenDataSettings _settings;

        public WarsawOpenDataService(IRemoteClient remoteClient, IOptions<WarsawOpenDataSettings> settings)
        {
            _remoteClient = remoteClient;
            _settings = settings.Value;
        }

        public async Task<IEnumerable<Notification>> GetReportedNotificationsAsync()
        {
            var response = await _remoteClient.GetAsync<NotificationsResponse>($"{_settings.ApiUrl}/19115store_getNotifications?id={_settings.ApiId}&apikey={_settings.ApiKey}");
            
            return response.Result.Data.Notifications;
        }
    }
}
