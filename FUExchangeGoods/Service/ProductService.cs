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
    }
}
