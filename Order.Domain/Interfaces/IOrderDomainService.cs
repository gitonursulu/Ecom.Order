using Order.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    public interface IOrderDomainService
    {
        Task<Order.Domain.Models.Order> CreateOrder(CreateOrderCommand Order);
        Task<Order.Domain.Models.Order> GetOrderById(int id);
    }
}
