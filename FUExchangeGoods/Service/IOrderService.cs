using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        void CreateTransactionAndOrder(int buyerId, int sellerId, int productId, int quantity);
        List<Order> GetOrdersByUserId(int userId);
        public int getTransactionByStatus(int status);
        List<Transaction> GetSellerTransactions(int sellerId);
        void UpdateTransactionStatus(int transactionId, int newStatus);
    }
}
