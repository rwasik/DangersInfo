using System.Collections.Generic;
using System.Threading.Tasks;
using DangersInfo.Services.Dtos;
using DangersInfo.Services.Mapping;
using WarsawOpenData.Proxy.Services;

namespace DangersInfo.Services.Services
{
    public class DangersInfoService : IDangersInfoService
    {
        private readonly IWarsawOpenDataService _warsawOpenDataService;
        private readonly INotificationToReportedDangerMapper _mapper;

        public DangersInfoService(IWarsawOpenDataService warsawOpenDataService, INotificationToReportedDangerMapper mapper)        
        {
            _warsawOpenDataService = warsawOpenDataService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportedDanger>> GetDangersAsync()
        {
            var notifications = await _warsawOpenDataService.GetReportedNotificationsAsync();

            var dangers = _mapper.Map(notifications);

            return dangers;
        }        
    }
}
