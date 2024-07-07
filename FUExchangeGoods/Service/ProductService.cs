using Models.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public List<Category> GetAllCategory()
        {
            return _repository.GetAllCategory();
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return _repository.GetProductsByCategoryId(categoryId);
        }
        public Product GetProductById(int productId)
        {
            return _repository.GetProductById(productId);
        }
        public List<Product> GetAllProducts(int pageIndex, int pageSize) => _repository.GetAllProducts(pageIndex, pageSize);
        public void AddProduct(Product product) => _repository.AddProduct(product);
        public void UpdateProduct(Product product) => _repository.UpdateProduct(product);
        public void ChangeProductStatus(int productId, int status) => _repository.ChangeProductStatus(productId, status);
        public Category GetCategoryById(int id) => _repository.GetCategoryById(id);
        public void AddCategory(Category category) => _repository.AddCategory(category);
        public void UpdateCategory(Category category) => _repository.UpdateCategory(category);
    }
}

