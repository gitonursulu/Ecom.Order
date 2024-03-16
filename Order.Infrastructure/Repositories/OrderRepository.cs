﻿using Order.Domain.Interfaces;
using Order.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SQLDbContext _sqlDbContext;
        public OrderRepository(SQLDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }
        public async Task CreateOrder(Domain.Models.Order Order)
        {
            await _sqlDbContext.Orders.AddAsync(Order);
        }
    }
}