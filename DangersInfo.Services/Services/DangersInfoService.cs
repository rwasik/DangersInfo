using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DangersInfo.Services.Dtos;
using WarsawOpenData.Proxy.Services;

namespace DangersInfo.Services.Services
{
    public class DangersInfoService : IDangersInfoService
    {
        private readonly IWarsawOpenDataService _warsawOpenDataService;
        private readonly IMapper _mapper;

        public DangersInfoService(IWarsawOpenDataService warsawOpenDataService, IMapper mapper)        
        {
            _warsawOpenDataService = warsawOpenDataService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportedDanger>> GetDangersAsync()
        {
            var notifications = await _warsawOpenDataService.GetReportedNotificationsAsync();

            var dangers = _mapper.Map<IEnumerable<ReportedDanger>>(notifications);

            return dangers;
        }        
    }
}
