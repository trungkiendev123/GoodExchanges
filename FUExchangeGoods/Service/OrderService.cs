﻿using DAO;
using Models.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService()
        {
            _repository = new OrderRepository();
        }
        public void CreateTransactionAndOrder(int buyerId, int sellerId, int productId, int quantity)
        {
            _repository.CreateTransactionAndOrder(buyerId, sellerId, productId, quantity);
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _repository.GetOrdersByUserId(userId);
        }
    }
}
