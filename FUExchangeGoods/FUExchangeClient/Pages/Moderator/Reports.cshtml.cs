using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Moderator
{
    public class ReportsModel : PageModel
    {
        private readonly IReportService _reportService;

        public ReportsModel(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IList<Report> Reports { get; set; }

        public void OnGet()
        {
            Reports = _reportService.GetAllReports();
        }
    }
}
