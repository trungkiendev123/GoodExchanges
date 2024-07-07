using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class EditAccountModel : PageModel
    {
        private readonly IAccountService _accountService;

        public EditAccountModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; }

        [BindProperty]
        public User user { get; set; } = new User();

        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            Account = _accountService.GetByID(id);
            user.FirstName = Account.User.FirstName;
            user.LastName = Account.User.LastName;
            user.Address = Account.User.Address;
            if (Account == null)
            {
                return RedirectToPage("./Accounts");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Account.User = user;    
                _accountService.Update(Account);
                return RedirectToPage("./Accounts");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ một cách thích hợp (ví dụ: logging)
                ModelState.AddModelError(string.Empty, "Error updating account: " + ex.Message);
                return Page();
            }
        }
    }
}
