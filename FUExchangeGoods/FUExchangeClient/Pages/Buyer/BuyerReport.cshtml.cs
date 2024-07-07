using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Buyer
{
    public class BuyerReportModel : PageModel
    {
        private readonly IReportService _reportService;
        private readonly IAccountService _accountService;

        public BuyerReportModel(IReportService reportService, IAccountService accountService)
        {
            _reportService = reportService;
            _accountService = accountService;
        }

        [BindProperty]
        public Report Report { get; set; }

        public List<User> Sellers { get; set; } = new List<User>();

        [BindProperty]
        public int userID { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            Sellers = _accountService.ListSeller(); // Example method to get list of buyers for dropdown
            return Page();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            if (!ModelState.IsValid)
            {
                Sellers = _accountService.ListSeller();  // Populate dropdown again if validation fails
                return Page();
            }

            try
            {
                Report.ReportDate = DateTime.Now;
                Report.BuyerId = _accountService.GetBuyerByUserID(HttpContext.Session.GetInt32("user_id").Value).BuyerId;
                Report.RoleReport = 0;
                Report.SellerId = _accountService.GetSellerByUserID(userID).SellerId;

                _reportService.AddReport(Report);
                Sellers = _accountService.ListSeller();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                Sellers = _accountService.ListSeller();    // Populate dropdown again if submission fails

            }
            return Page();
        }
    }
}
