using System.Threading.Tasks;
using DangersInfo.Services.Services;
using DangersInfoApp.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace DangersInfoApp.Controllers
{
    public class DangersController : Controller
    {
        private readonly IDangersInfoService _dangersInfoService;
        private readonly IReportedDangersToViewModelMapper _mapper;

        public DangersController(IDangersInfoService dangersInfoService, IReportedDangersToViewModelMapper mapper)
        {
            _dangersInfoService = dangersInfoService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dangers = await _dangersInfoService.GetDangersAsync();

            var viewModel = _mapper.Map(dangers);

            return new JsonResult(viewModel);
        }
    }
}
