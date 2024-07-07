using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class CategoryModel : PageModel
    {
        private readonly IProductService _productService;

        public CategoryModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Category> Categories { get; set; }

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
            Categories = _productService.GetAllCategory();
            return Page();
        }
    }
}
