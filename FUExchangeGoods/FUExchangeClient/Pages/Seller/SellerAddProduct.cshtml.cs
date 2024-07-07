using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Seller
{
    public class SellerAddProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IAccountService _accountService;

        public SellerAddProductModel(IProductService productService, IAccountService accountService)
        {
            _productService = productService;
            _accountService = accountService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public SelectList Categories { get; set; }

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
            Categories = new SelectList(_productService.GetAllCategory(), "CategoryId", "CategoryName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            if (!ModelState.IsValid)
            {
                Categories = new SelectList(_productService.GetAllCategory(), "CategoryId", "CategoryName");
                return Page();
            }
            Product.Status = 1;
            Product.SellerId = HttpContext.Session.GetInt32("user_id").Value;
            Product.DatePosted = DateTime.Now;
            _productService.AddProduct(Product);
            return RedirectToPage("./SellerProducts");
        }
    }
}
