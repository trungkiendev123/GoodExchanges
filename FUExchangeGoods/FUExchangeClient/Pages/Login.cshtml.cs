using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Repository;
using Service;

namespace FUExchangeClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService service;
        private readonly ICartService serviceCart;

        public LoginModel()
        {
            service = new AccountService();
            serviceCart = new CartService();
        }
        public IActionResult OnGetAsync()
        {
            return Page();
        }
        public string error { get; set; } = default!;
        public string success { get; set; } = default!;

        public string errorRegister { get; set; } = default!;

        [BindProperty]
        public Account account { get; set; } = default!;

        [BindProperty]
        public User user { get; set; } = default!;

        public IActionResult OnPostAsync()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            var account = service.getByNameAndPass(username, password);
            if (account == null)
            {
                error = "Wrong Account";
                return Page();
            }
            else
            {
                HttpContext.Session.SetInt32("user_id", account.AccountId);
                HttpContext.Session.SetInt32("role", (int)account.Role);
                if (account.Role == 0)
                {
                    return RedirectToPage("/Guest/ProductList");
                }
                else
                {
                    return Redirect("/Error");
                }



            }

        }
        public IActionResult OnPostSubmitAsync()
        {
            if (service.getByName(account.Username) != null)
            {
                errorRegister = "Username : " + account.Username + " already exist";
                return Page();
            }
            if (account.Username.Length >= 100 || account.Password.Length >= 100 || account.Email.Length >= 100 )
            {
                errorRegister = "All text is not over 100 characters";
                return Page();
            }
            success = "Register successfully";
            account.Status = 1;
            service.Add(account,user);
            serviceCart.CreateCart(user.UserId);

            return Page();

        }
    }
}
