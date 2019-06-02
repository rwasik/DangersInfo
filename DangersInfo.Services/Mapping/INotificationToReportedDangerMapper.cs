using System.Collections.Generic;
using DangersInfo.Services.Dtos;
using WarsawOpenData.Proxy.Contracts;

namespace DangersInfo.Services.Mapping
{
    public interface INotificationToReportedDangerMapper
    {
        IEnumerable<ReportedDanger> Map(IEnumerable<Notification> notifications);
    }
}
