using System;
using System.Collections.Generic;
using DangersInfo.Services.Dtos;
using WarsawOpenData.Proxy.Contracts;

namespace DangersInfo.Services.Mapping
{
    public class NotificationToReportedDangerMapper : INotificationToReportedDangerMapper
    {
        public IEnumerable<ReportedDanger> Map(IEnumerable<Notification> notifications)
        {
            var dangers = new List<ReportedDanger>();

            foreach (var notification in notifications)
            {
                dangers.Add(new ReportedDanger
                {
                    Category = notification.Category,
                    City = notification.City,
                    District = notification.District,
                    NotificationType = notification.NotificationType,
                    Source = notification.Source,
                    Street = notification.Street,
                    Subcategory = notification.Subcategory,
                    CreateDate = UnixTimeStampToDateTime(double.Parse(notification.CreateDate))
                });
            }

            return dangers;
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var initialDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return initialDate.AddMilliseconds(unixTimeStamp).ToLocalTime();
        }
    }
}
