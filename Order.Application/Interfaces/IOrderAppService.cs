using Order.Domain.Commands;
using Order.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task CreateOrder(CreateOrderCommand OrderCommand);
        Task<string> GetOrderById(GetOrderByIdQuery OrderQuery);
    }
}
