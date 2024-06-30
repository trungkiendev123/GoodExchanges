using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Guest
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductDetailModel(IProductService productService)
        {
            _productService = productService;
        }

        public Product Product { get; set; }
        public User Seller { get; set; }

        public void OnGet(int productId)
        {
            Product = _productService.GetProductById(productId);
            Seller = Product.Seller.User;
        }
    }
}
