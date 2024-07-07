using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Seller
{
    public class SellerProductsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IAccountService _accountService;

        public SellerProductsModel(IProductService productService, IAccountService accountService)
        {
            _productService = productService;
            _accountService = accountService;
        }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        public IList<Product> Products { get; set; }

        public int PageSize { get; set; } = 4;

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => Products.Count == PageSize;

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
            Models.Models.Seller seller = _accountService.GetSellerByUserID(HttpContext.Session.GetInt32("user_id").Value);
            Products = _productService.GetAllProductsSeller(seller.SellerId,PageIndex, PageSize);
            return Page();
        }

        public IActionResult OnPostChangeStatus(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 1)
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
