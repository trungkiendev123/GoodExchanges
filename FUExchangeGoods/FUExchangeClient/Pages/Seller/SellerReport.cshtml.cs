using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Seller
{
    public class SellerReportModel : PageModel
    {
        private readonly IReportService _reportService;
        private readonly IAccountService _accountService;

        public SellerReportModel(IReportService reportService, IAccountService accountService)
        {
            _reportService = reportService;
            _accountService = accountService;
        }

        [BindProperty]
        public Report Report { get; set; }

        public List<User> Buyers { get; set; } = new List<User>();

        [BindProperty]
        public int userID { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            Buyers = _accountService.ListBuyer(); // Example method to get list of buyers for dropdown
            return Page();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            if (!ModelState.IsValid)
            {
                Buyers = _accountService.ListBuyer();  // Populate dropdown again if validation fails
                return Page();
            }

            try
            {
                Report.ReportDate = DateTime.Now;
                Report.SellerId = _accountService.GetSellerByUserID(HttpContext.Session.GetInt32("user_id").Value).SellerId;
                Report.RoleReport = 1;
                Report.BuyerId = _accountService.GetBuyerByUserID(userID).BuyerId;
                _reportService.AddReport(Report);
                Buyers = _accountService.ListBuyer();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                Buyers = _accountService.ListBuyer();  // Populate dropdown again if submission fails
                
            }
            return Page();
        }
    }
}
