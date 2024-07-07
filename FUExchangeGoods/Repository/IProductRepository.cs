using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        List<Product> GetAllProducts();
        List<Product> GetProductsByCategoryId(int categoryId);
        List<Category> GetAllCategory();
        Product GetProductById(int productId);
        List<Product> GetAllProducts(int pageIndex, int pageSize);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void ChangeProductStatus(int productId, int status);
        public List<Product> GetAllProductsSeller(int sellerID, int pageIndex, int pageSize);

    }
}
