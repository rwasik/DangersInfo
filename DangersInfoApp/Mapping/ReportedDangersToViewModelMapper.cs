using System.Collections.Generic;
using DangersInfo.Services.Dtos;
using DangersInfoApp.ViewModels;

namespace DangersInfoApp.Mapping
{
    public class ReportedDangersToViewModelMapper : IReportedDangersToViewModelMapper
    {
        public DangersViewModel Map(IEnumerable<ReportedDanger> reportedDangers)
        {
            var viewModel = new DangersViewModel();

            foreach (var reportedDanger in reportedDangers)
            {
                viewModel.ReportedDangers.Add(new ReportedDangerViewModel
                {
                    Category = reportedDanger.Category,
                    City = reportedDanger.City,
                    District = reportedDanger.District,
                    NotificationType = reportedDanger.NotificationType,
                    Source = reportedDanger.Source,
                    Street = reportedDanger.Street,
                    Subcategory = reportedDanger.Subcategory,
                    CreateDate = reportedDanger.CreateDate.ToShortDateString()
                });
            }

            return viewModel;
        }
    }
}
