using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Admin
{
    public class ProductsModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductsModel(IProductService productService)
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
