using System.Collections.Generic;
using System.Threading.Tasks;
using WarsawOpenData.Proxy.Contracts;

namespace WarsawOpenData.Proxy.Services
{
    public interface IWarsawOpenDataService
    {
        Task<IEnumerable<Notification>> GetReportedNotificationsAsync();
    }
}
