using System.Collections.Generic;
using DangersInfo.Services.Dtos;
using DangersInfoApp.ViewModels;

namespace DangersInfoApp.Mapping
{
    public interface IReportedDangersToViewModelMapper
    {
        DangersViewModel Map(IEnumerable<ReportedDanger> reportedDangers);
    }
}
