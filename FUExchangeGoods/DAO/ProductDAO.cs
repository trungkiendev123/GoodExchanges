using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock =  new object();
        private ProductDAO() { }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var context = new FUExchangeGoodsContext()) 
                {
                    products = context.Products.Where(x => x.Status == 1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products from database.", ex);
            }
            return products;
        }
        public List<Category> GetAllCategory()
        {
            List<Category> cates = new List<Category>();
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    cates = context.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving category from database.", ex);
            }
            return cates;
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var context = new FUExchangeGoodsContext()) 
                {
                    products = context.Products.Where(p => p.CategoryId == categoryId && p.Status == 1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by category from database.", ex);
            }
            return products;
        }
        public Product GetProductById(int productId)
        {
            Product product = null;
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    product = context.Products.Include(p => p.Category)
                                    .Include(p => p.Seller)
                                    .ThenInclude(s => s.User)
                                    .FirstOrDefault(p => p.ProductId == productId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by ID from database.", ex);
            }
            return product;
        }
        public List<Product> GetAllProducts(int pageIndex, int pageSize)
        {
            List<Product> products = null;
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    products = context.Products.Include(p => p.Seller).ThenInclude(x => x.User).Include(p => p.Category)
                        .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving all products.", e);
            }
            return products;
        }

       

        public void AddProduct(Product product)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding product.", e);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error updating product.", e);
            }
        }

        public void ChangeProductStatus(int productId, int status)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var product = context.Products.Find(productId);
                    if (product != null)
                    {
                        product.Status = status;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error changing product status.", e);
            }
        }
        public Category GetCategoryById(int id)
        {
            Category category = null;
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    category = context.Categories.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving category.", e);
            }
            return category;
        }

        public void AddCategory(Category category)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding category.", e);
            }
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    context.Categories.Update(category);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error updating category.", e);
            }
        }
    }
}
