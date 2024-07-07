using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IAccountService _accountService;

        public AddProductModel(IProductService productService, IAccountService accountService)
        {
            _productService = productService;
            _accountService = accountService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public SelectList Categories { get; set; }
        public List<User> Sellers { get; set; }

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
            Categories = new SelectList(_productService.GetAllCategory(), "CategoryId", "CategoryName");
            Sellers = _accountService.ListSeller();
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
                Categories = new SelectList(_productService.GetAllCategory(), "CategoryId", "CategoryName");
                Sellers = _accountService.ListSeller();
                return Page();
            }
            Product.Status = 1;
            Product.DatePosted = DateTime.Now;
            _productService.AddProduct(Product);
            return RedirectToPage("./Products");
        }
    }
}
