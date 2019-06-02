using System.Collections.Generic;

namespace WarsawOpenData.Proxy.Contracts
{
    public class NotificationsData
    {
        public IEnumerable<Notification> Notifications { get; set; }
    }
}
