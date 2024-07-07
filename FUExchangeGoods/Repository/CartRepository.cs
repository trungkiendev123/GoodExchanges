using DAO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        public void CreateCart(int userId)
        {
            CartDAO.Instance.CreateCart(userId);
        }
        public List<CartItem> GetCartItems(int userId)
        {
            return CartDAO.Instance.GetCartItems(userId);
        }

        public void AddCartItem(int userId, int productId, int quantity)
        {
            CartDAO.Instance.AddCartItem(userId, productId, quantity);
        }

        public void UpdateCartItem(int cartItemId, int quantity)
        {
            CartDAO.Instance.UpdateCartItem(cartItemId, quantity);
        }

        public void DeleteCartItem(int cartItemId)
        {
            CartDAO.Instance.DeleteCartItem(cartItemId);
        }

       
        public CartItem GetCartItemById(int cartItemId)
        {
            return CartDAO.Instance.GetCartItemById(cartItemId);
        }

        public CartItem GetCartItemByProductID(int productID, int userID)
        {
            return CartDAO.Instance.GetCartItemByProductID(productID, userID);
        }
    }
}
