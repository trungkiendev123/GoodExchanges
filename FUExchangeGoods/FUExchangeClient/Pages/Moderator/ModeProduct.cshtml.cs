using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Moderator
{
    public class ModeProductModel : PageModel
    {
        private readonly IProductService _productService;

        public ModeProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        public IList<Product> Products { get; set; }

        public int PageSize { get; set; } = 4;

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => Products.Count == PageSize;

        public void OnGet()
        {
            Products = _productService.GetAllProducts(PageIndex, PageSize);
        }

        public IActionResult OnPostChangeStatus(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 3)
            {
                return RedirectToPage("/AccessDenied");
            }
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                var newStatus = product.Status == 1 ? 0 : 1;
                _productService.ChangeProductStatus(id, newStatus);
            }

            return RedirectToPage(new { PageIndex });
        }
    }
}
