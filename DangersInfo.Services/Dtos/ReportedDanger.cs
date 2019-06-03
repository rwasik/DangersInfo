using System;

namespace DangersInfo.Services.Dtos
{
    public class ReportedDanger
    {
        public string Category { get; set; }
        public string City { get; set; }
        public string Subcategory { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string NotificationType { get; set; }
        public string NotificationNumber { get; set; }
        public string Source { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
