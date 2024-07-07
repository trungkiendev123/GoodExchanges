using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICartRepository
    {
        void CreateCart(int userId);
        List<CartItem> GetCartItems(int userId);
        void AddCartItem(int userId, int productId, int quantity);
        void UpdateCartItem(int cartItemId, int quantity);
        void DeleteCartItem(int cartItemId);

      

        CartItem GetCartItemById(int cartItemId);

        public CartItem GetCartItemByProductID(int productID, int userID);
    }
}
