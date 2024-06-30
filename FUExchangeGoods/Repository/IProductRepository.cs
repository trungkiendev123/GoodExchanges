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
        List<Product> GetAllProducts();
        List<Product> GetProductsByCategoryId(int categoryId);
        List<Category> GetAllCategory();
        Product GetProductById(int productId);

    }
}
