using Models.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService()
        {
            _repository = new CartRepository();
        }

        public void CreateCart(int userId)
        {
            _repository.CreateCart(userId);
        }

        public List<CartItem> GetCartItems(int userId)
        {
            return _repository.GetCartItems(userId);
        }

        public void AddCartItem(int userId, int productId, int quantity)
        {
            _repository.AddCartItem(userId, productId, quantity);
        }

        public void UpdateCartItem(int cartItemId, int quantity)
        {
            _repository.UpdateCartItem(cartItemId, quantity);
        }

        public void DeleteCartItem(int cartItemId)
        {
            _repository.DeleteCartItem(cartItemId);
        }

        
        public CartItem GetCartItemById(int cartItemId)
        {
            return _repository.GetCartItemById(cartItemId);
        }
    }
}
