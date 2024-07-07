using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;
using System.Data;

namespace FUExchangeClient.Pages.Guest
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public ProductDetailModel(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public Product Product { get; set; }
        public User Seller { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProductById(id);
            Seller = Product.Seller.User;
            return Page();
        }
        public IActionResult OnPostAddToCart(int productId, int quantity)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            if(_cartService.GetCartItemByProductID(productId, HttpContext.Session.GetInt32("user_id").Value) != null)
            {
                TempData["SuccessMessage"] = "Product already in cart.Cannot add";
            }
            else
            {
                _cartService.AddCartItem(HttpContext.Session.GetInt32("user_id").Value, productId, quantity);
                TempData["SuccessMessage"] = "Product added to cart successfully!";
            }
           
            return RedirectToPage("/Guest/ProductDetail", new { id = productId });
        }
    }
}
