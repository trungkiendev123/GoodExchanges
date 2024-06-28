using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Guest
{
    public class ProductListModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductListModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public int? SelectedCategoryId { get; set; }

        public void OnGet(int? categoryId)
        {
            SelectedCategoryId = categoryId;
            Products = categoryId.HasValue ? _productService.GetProductsByCategoryId(categoryId.Value) : _productService.GetAllProducts();
            Categories = GetCategories(); 
        }

        private List<Category> GetCategories()
        {
            return _productService.GetAllCategory();
        }
    }
}
