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
        // Bağımlılıklar burada enjekte edilir.

        public GetOrderByIdQueryHandler(IOrderDomainService orderDomainService)
        {
            _orderDomainService = orderDomainService;
        }

        public async Task<string> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _orderDomainService.GetOrderById(request.Id);

            if (user == null)
            {
                return null; // Kullanıcı bulunamazsa null döndürülür.
            }

            return "";
        }
    }

}
