using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class CreateAccountModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateAccountModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; }
        [BindProperty]
        public User User { get; set; }

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
            Account = new Account(); // Khởi tạo một tài khoản mới khi vào trang Create
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

            // Kiểm tra username không trùng
            var existingAccount = _accountService.getByName(Account.Username);
            if (existingAccount != null)
            {
                ModelState.AddModelError("Account.Username", "Username is already taken.");
                return Page();
            }

            try
            {
                Account.Status = 1;
                _accountService.Add(Account,User); // Gọi service để tạo tài khoản mới
                return RedirectToPage("./Accounts");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ một cách thích hợp (ví dụ: logging)
                ModelState.AddModelError(string.Empty, "Error creating account: " + ex.Message);
                return Page();
            }
        }
    }
}
