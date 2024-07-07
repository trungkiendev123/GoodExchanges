using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class AccountsModel : PageModel
    {
        private readonly IAccountService _accountService;

        public int PageSize = 5; // Số lượng account trên mỗi trang

        public AccountsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty(SupportsGet = true)]
        public string FilterType { get; set; } = "All";

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1; // Trang hiện tại, mặc định là trang 1

        [BindProperty(SupportsGet = true)]
        public int TotalPage { get; set; } = -1;
        public IList<Account> Accounts { get; set; }
        public SelectList FilterOptions { get; set; } = new SelectList(new[]
        {
            new { Value = "All", Text = "All Accounts" },
            new { Value = "Active", Text = "Active Accounts" },
            new { Value = "Banned", Text = "Banned Accounts" }
        }, "Value", "Text");

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            switch (FilterType)
            {
                case "Active":
                    Accounts = _accountService.GetActiveAccounts();
                    break;
                case "Banned":
                    Accounts = _accountService.GetBannedAccounts();
                    break;
                default:
                    Accounts = _accountService.GetAllAccounts();
                    break;
            }
            if (Accounts.Count % 5 == 0)
            {
                TotalPage = Accounts.Count / 5;
            }
            else
            {
                TotalPage = (Accounts.Count / 5) + 1;
            }

            // Phân trang
            Accounts = Accounts.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            return Page();
            
        }

        public IActionResult OnPostActivate(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            try
            {
                _accountService.ActiveAccount(id);
                return RedirectToPage(new { FilterType, PageIndex });
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ một cách thích hợp (ví dụ: logging)
                ModelState.AddModelError(string.Empty, "Error activating account: " + ex.Message);
                return Page();
            }
        }

        public IActionResult OnPostDeactivate(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            try
            {
                _accountService.BanAccount(id);
                return RedirectToPage(new { FilterType, PageIndex });
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ một cách thích hợp (ví dụ: logging)
                ModelState.AddModelError(string.Empty, "Error deactivating account: " + ex.Message);
                return Page();
            }
        }
    }
}
