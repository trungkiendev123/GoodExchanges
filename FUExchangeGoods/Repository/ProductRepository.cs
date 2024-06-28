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
    }
}
