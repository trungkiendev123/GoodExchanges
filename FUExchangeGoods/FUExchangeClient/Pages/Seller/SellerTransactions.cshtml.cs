using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Repository;
using Service;


namespace FUExchangeClient.Pages.Seller
{ 
    public class SellerTransactionsModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;

        public SellerTransactionsModel(IOrderService orderService, IAccountService accountService)
        {
            _orderService = orderService;
            _accountService = accountService;
        }

        public List<Transaction> Transactions { get; set; }

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
            Models.Models.Seller seller = _accountService.GetSellerByUserID(HttpContext.Session.GetInt32("user_id").Value);


            Transactions = _orderService.GetSellerTransactions(seller.SellerId);
            return Page();
        }

        public IActionResult OnPostCancel(int transactionId)
        {
            try
            {
                _orderService.UpdateTransactionStatus(transactionId, 3); // Update to Cancel status
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error canceling transaction: " + ex.Message);
                return Page();
            }
        }

        public IActionResult OnPostShip(int transactionId)
        {
            try
            {
                _orderService.UpdateTransactionStatus(transactionId, 1); // Update to Ship status
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error shipping transaction: " + ex.Message);
                return Page();
            }
        }

        public IActionResult OnPostComplete(int transactionId)
        {
            try
            {
                _orderService.UpdateTransactionStatus(transactionId, 2); // Update to Complete status
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error completing transaction: " + ex.Message);
                return Page();
            }
        }
    }
}
