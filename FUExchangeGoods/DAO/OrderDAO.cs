using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public int getTransactionByStatus(int status)
        {
            using (var context = new FUExchangeGoodsContext())
            {
                return context.Transactions.Where(x => x.Status == status).Count();
            }
        }
        public void CreateTransactionAndOrder(int buyerId, int sellerId, int productId, int quantity)
        {
            using (var context = new FUExchangeGoodsContext())
            {
                var newTransaction = new Transaction
                {
                    BuyerId = buyerId,
                    SellerId = sellerId,
                    ProductId = productId,
                    Status = 0
                };
                context.Transactions.Add(newTransaction);
                context.SaveChanges();

                var newOrder = new Order
                {
                    BuyerId = buyerId,
                    SellerId = sellerId,
                    ProductId = productId,
                    Quantity = quantity,
                    TransactionId = newTransaction.TransactionId
                };
                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            using (var context = new FUExchangeGoodsContext())
            {
                var bID = context.Buyers.FirstOrDefault(X => X.UserId == userId);
                return context.Orders
                .Include(o => o.Product)
                    .ThenInclude(p => p.Seller)
                        .ThenInclude(s => s.User)
                .Include(o => o.Buyer)
                .Include(o => o.Transaction)
                .Where(o => o.BuyerId == bID.BuyerId)
                .ToList();
            }
        }
        
    }
}
