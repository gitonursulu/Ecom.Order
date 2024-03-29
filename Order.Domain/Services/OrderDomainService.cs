﻿using Order.Domain.Commands;
using Order.Domain.Entities;
using Order.Domain.Events;
using Order.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        public Task<Models.Order> CreateOrder(CreateOrderCommand Order)
        {
            var order = new Models.Order
            {
                OrderAddress = new ValueObjects.OrderAddress
                {
                    City = "istanbul",
                    PostCode = "23232"
                }
            };
            order.AddDomainEvent(new OrderCreatedEvent(Guid.NewGuid(), "123123", new DateTime()));

            return Task.FromResult(order);
        }

        public Task<Models.Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
