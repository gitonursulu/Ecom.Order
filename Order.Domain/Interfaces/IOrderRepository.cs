﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order.Domain.Models.Order Order);
        Task<Order.Domain.Models.Order> GetOrderById(Guid id);
    }
}
