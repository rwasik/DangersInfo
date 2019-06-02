using System.Collections.Generic;

namespace DangersInfoApp.ViewModels
{
    public class DangersViewModel
    {
        public DangersViewModel()
        {
            ReportedDangers = new List<ReportedDangerViewModel>();
        }

        public ICollection<ReportedDangerViewModel> ReportedDangers { get; }
    }
}
