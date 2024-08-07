﻿using DAO;
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
        public int getTransactionByStatus(int status)
        {
            return OrderDAO.Instance.getTransactionByStatus(status);
        }
        public List<Transaction> GetSellerTransactions(int sellerId) => OrderDAO.Instance.GetSellerTransactions(sellerId);

        public void UpdateTransactionStatus(int transactionId, int newStatus) => OrderDAO.Instance.UpdateTransactionStatus(transactionId, newStatus);
    }
}
