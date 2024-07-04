using DAO;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateTransactionAndOrder(int buyerId, int sellerId, int productId, int quantity)
        {
             OrderDAO.Instance.CreateTransactionAndOrder(buyerId,sellerId,productId,quantity);
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
           return OrderDAO.Instance.GetOrdersByUserId(userId);
        }
    }
}
