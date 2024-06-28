using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
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
                    products = context.Products.ToList();
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
                    products = context.Products.Where(p => p.CategoryId == categoryId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by category from database.", ex);
            }
            return products;
        }
    }
}
