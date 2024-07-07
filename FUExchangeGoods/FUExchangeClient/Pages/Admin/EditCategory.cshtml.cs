using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class EditCategoryModel : PageModel
    {
        private readonly IProductService _productService;

        public EditCategoryModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Category Category { get; set; }

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
            Category = _productService.GetCategoryById(id);
            if (Category == null)
            {
                return NotFound();
            }
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
                return Page();
            }

            _productService.UpdateCategory(Category);
            return RedirectToPage("Category");
        }
    }
}
