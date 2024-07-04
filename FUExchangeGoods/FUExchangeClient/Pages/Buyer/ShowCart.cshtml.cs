using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Buyer
{
    public class ShowCartModel : PageModel
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;


        public ShowCartModel(ICartService cartService, IOrderService orderService, IAccountService accountService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _accountService = accountService;
        }

        public List<CartItem> CartItems { get; set; }

        public int sellerID { get; set; }

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

        public IActionResult OnPostOrderCart(int cartItemId, int quantity, int productId)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            int userId = HttpContext.Session.GetInt32("user_id").Value;
            Models.Models.Buyer buyer = _accountService.GetBuyerByUserID(userId);
            var cartItem = _cartService.GetCartItemById(cartItemId);

            if (cartItem != null)
            {
                _orderService.CreateTransactionAndOrder(buyer.BuyerId, (int)cartItem.Product.SellerId, (int)cartItem.ProductId, (int)cartItem.Quantity);
                _cartService.DeleteCartItem(cartItemId);
                TempData["SuccessMessage"] = "New transaction is on pending";
            }
            

            return RedirectToPage();
        }


    }
}
