using DAO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public Category GetCategoryById(int id) => ProductDAO.Instance.GetCategoryById(id);
        public void AddCategory(Category category) => ProductDAO.Instance.AddCategory(category);
        public void UpdateCategory(Category category) => ProductDAO.Instance.UpdateCategory(category);
        public List<Category> GetAllCategory()
        {
            return ProductDAO.Instance.GetAllCategory();
        }

        public List<Product> GetAllProducts()
        {
            return ProductDAO.Instance.GetAllProducts();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return ProductDAO.Instance.GetProductsByCategoryId(categoryId);
        }
        public Product GetProductById(int productId)
        {
            return ProductDAO.Instance.GetProductById(productId);
        }
        public List<Product> GetAllProducts(int pageIndex, int pageSize) => ProductDAO.Instance.GetAllProducts(pageIndex, pageSize);
        public void AddProduct(Product product) => ProductDAO.Instance.AddProduct(product);
        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
        public void ChangeProductStatus(int productId, int status) => ProductDAO.Instance.ChangeProductStatus(productId, status);
        public List<Product> GetAllProductsSeller(int sellerID, int pageIndex, int pageSize)
        {
            return ProductDAO.Instance.GetAllProductsSeller(sellerID, pageIndex, pageSize);
        }
    }
}
