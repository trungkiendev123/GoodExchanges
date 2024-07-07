using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class CreateCategoryModel : PageModel
    {
        private readonly IProductService _productService;

        public CreateCategoryModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet()
        {
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
                return Page();
            }

            _productService.AddCategory(Category);
            return RedirectToPage("Category");
        }
    }
}
