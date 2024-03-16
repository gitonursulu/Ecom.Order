using MediatR;

namespace Order.Domain.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public string OrderName { get; set; }
    }
}
