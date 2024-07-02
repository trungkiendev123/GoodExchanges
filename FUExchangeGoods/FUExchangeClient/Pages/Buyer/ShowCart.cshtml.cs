using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Buyer
{
    public class ShowCartModel : PageModel
    {
        private readonly ICartService _cartService;

        public ShowCartModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        public List<CartItem> CartItems { get; set; }

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
            int UserId = (int)HttpContext.Session.GetInt32("user_id");
            CartItems = _cartService.GetCartItems(UserId);
            return Page();
        }

        public IActionResult OnPostUpdateCart(int cartItemId, int quantity)
        {

            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }

            _cartService.UpdateCartItem(cartItemId, quantity);
            TempData["SuccessMessage"] = "Cart item updated successfully.";
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteCartItem(int cartItemId)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            _cartService.DeleteCartItem(cartItemId);
            TempData["SuccessMessage"] = "Cart item deleted successfully.";
            return RedirectToPage();
        }

        
    }
}
