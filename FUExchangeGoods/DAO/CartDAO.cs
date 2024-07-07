using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CartDAO
    {
        private static CartDAO instance = null;
        private static readonly object instanceLock = new object();
        private CartDAO() { }

        public static CartDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartDAO();
                    }
                    return instance;
                }
            }
        }
        public void CreateCart(int userId)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var cart = new Cart
                    {
                        UserId = userId
                    };
                    context.Carts.Add(cart);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating cart in database.", ex);
            }
        }
        public List<CartItem> GetCartItems(int userId)
        {
            List<CartItem> cartItems = new List<CartItem>();
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    cartItems = context.CartItems
                        .Include(c => c.Product).ThenInclude(x => x.Seller)
                        .Include(c => c.Cart)
                        .Where(c => c.Cart.UserId == userId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving cart items from database.", ex);
            }
            return cartItems;
        }
        public CartItem GetCartItemByProductID(int productID,int userID)
        {
           
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    return context.CartItems
                        .Include(c => c.Product).ThenInclude(x => x.Seller)
                        .Include(c => c.Cart)
                        .FirstOrDefault(c => c.Cart.UserId == userID && c.ProductId == productID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving cart items from database.", ex);
            }
            return null;
        }

        public void AddCartItem(int userId, int productId, int quantity)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var cart = context.Carts.FirstOrDefault(c => c.UserId == userId);
                    if (cart == null)
                    {
                        cart = new Cart { UserId = userId };
                        context.Carts.Add(cart);
                        context.SaveChanges();
                    }

                    var cartItem = context.CartItems.FirstOrDefault(ci => ci.CartId == cart.CartId && ci.ProductId == productId);
                    if (cartItem == null)
                    {
                        context.CartItems.Add(new CartItem
                        {
                            CartId = cart.CartId,
                            ProductId = productId,
                            Quantity = quantity
                        });
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding cart item to database.", ex);
            }
        }

        public void UpdateCartItem(int cartItemId, int quantity)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var cartItem = context.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
                    if (cartItem != null)
                    {
                        cartItem.Quantity = quantity;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating cart item in database.", ex);
            }
        }

        public void DeleteCartItem(int cartItemId)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var cartItem = context.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
                    if (cartItem != null)
                    {
                        context.CartItems.Remove(cartItem);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting cart item from database.", ex);
            }
        }
        
        public CartItem GetCartItemById(int cartItemId)
        {
            using (var context = new FUExchangeGoodsContext())
            {
                return context.CartItems.Include(x => x.Product).ThenInclude(x => x.Seller).FirstOrDefault(ci => ci.CartItemId == cartItemId);
            }
        }
    }
}
