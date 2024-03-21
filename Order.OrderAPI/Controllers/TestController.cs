using Microsoft.AspNetCore.Mvc;
using Order.Application.Interfaces;
using Order.Domain.Commands;
using Order.Domain.Queries;

namespace Order.OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        public TestController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _orderAppService.GetOrderById(new GetOrderByIdQuery { Id = id });

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommand OrderCommand)
        {
            await _orderAppService.CreateOrder(OrderCommand);

            return Ok("ben order api post");
        }
    }
}
