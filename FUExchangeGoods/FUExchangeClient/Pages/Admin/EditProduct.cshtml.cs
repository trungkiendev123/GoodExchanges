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

        public void OnGet(int id)
        {
            Product = _productService.GetProductById(id);
            Categories = new SelectList(_productService.GetAllCategory(), "CategoryId", "CategoryName");
        }

        public IActionResult OnPost()
        {
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
