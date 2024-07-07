using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Seller
{
    public class SellerContactModel : PageModel
    {
        private readonly IContactService _contactService;
        private readonly IAccountService _accountService;

        public SellerContactModel(IContactService contactService, IAccountService accountService)
        {
            _contactService = contactService;
            _accountService = accountService;
        }

        public List<User> Buyers { get; set; }
        public List<Contact> Messages { get; set; }
        public User SelectedBuyer { get; set; }

        public int UserId { get; set; }


        public IActionResult OnGetAsync(int? buyerId)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            Buyers = _accountService.ListBuyer();
            UserId = HttpContext.Session.GetInt32("user_id") ?? 0; // Assuming user ID is stored in session

            if (buyerId.HasValue)
            {
                SelectedBuyer = _accountService.GetUser(buyerId.Value);
                Messages = _contactService.GetMessages(buyerId.Value, UserId);
            }
            return Page();
        }

        public IActionResult OnPostAsync(int buyerId, string message)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            UserId = HttpContext.Session.GetInt32("user_id") ?? 0;

            if (!string.IsNullOrWhiteSpace(message))
            {
                var contactMessage = new Contact
                {
                    UserSend = UserId,
                    UserReceive = buyerId,
                    Message = message
                };

                _contactService.SendMessage(contactMessage);
            }

            return RedirectToPage(new { buyerId });
        }
    }
}
