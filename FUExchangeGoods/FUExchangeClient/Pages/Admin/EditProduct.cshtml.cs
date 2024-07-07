using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class EditProductModel : PageModel
    {
        private readonly IProductService _productService;

        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public SelectList Categories { get; set; }

        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            Product = _productService.GetProductById(id);
            Categories = new SelectList(_productService.GetAllCategory(), "CategoryId", "CategoryName");
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
                return Page();
            }

            _productService.UpdateProduct(Product);
            return RedirectToPage("./Products");
        }
    }
}
