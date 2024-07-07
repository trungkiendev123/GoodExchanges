using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Buyer
{
    public class ContactModel : PageModel
    {
        private readonly IContactService _contactService;
        private readonly IAccountService _accountService; 

        public ContactModel(IContactService contactService, IAccountService accountService)
        {
            _contactService = contactService;
            _accountService = accountService;
        }

        public List<User> Sellers { get; set; }
        public List<Contact> Messages { get; set; }
        public User SelectedSeller { get; set; }

        public int UserId { get; set; }
       

        public IActionResult OnGetAsync(int? sellerId)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            Sellers = _accountService.ListSeller();
            UserId = HttpContext.Session.GetInt32("user_id") ?? 0; // Assuming user ID is stored in session

            if (sellerId.HasValue)
            {
                SelectedSeller = _accountService.GetUser(sellerId.Value);
                Messages =  _contactService.GetMessages(UserId, sellerId.Value);
            }
            return Page();
        }

        public IActionResult OnPostAsync(int sellerId, string message)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            UserId = HttpContext.Session.GetInt32("user_id") ?? 0;

            if (!string.IsNullOrWhiteSpace(message))
            {
                var contactMessage = new Contact
                {
                    UserSend = UserId,
                    UserReceive = sellerId,
                    Message = message
                };

                 _contactService.SendMessage(contactMessage);
            }

            return RedirectToPage(new { sellerId });
        }
    }
}
