using MediatR;
using Order.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, string>
    {
        private readonly IOrderDomainService _orderDomainService;
        private readonly IOrderRepository _orderRepository;

        // Bağımlılıklar burada enjekte edilir.

        public GetOrderByIdQueryHandler(IOrderDomainService orderDomainService, IOrderRepository orderRepository)
        {
            _orderDomainService = orderDomainService;
            _orderRepository = orderRepository;
        }

        public async Task<string> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var orderId = request.Id;
            var order = await _orderRepository.GetOrderById(orderId);

            return order.OrderAddress.City;
        }
    }

}
