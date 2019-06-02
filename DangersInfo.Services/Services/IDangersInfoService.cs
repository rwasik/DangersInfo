using System.Collections.Generic;
using System.Threading.Tasks;
using DangersInfo.Services.Dtos;

namespace DangersInfo.Services.Services
{
    public interface IDangersInfoService
    {
        Task<IEnumerable<ReportedDanger>> GetDangersAsync();
    }
}
