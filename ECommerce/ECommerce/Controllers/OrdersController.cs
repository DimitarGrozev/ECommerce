using ECommerce.Contracts;
using ECommerce.Services;
using ECommerce.Utilities.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly OrdersService ordersService;

        public OrdersController(
            ILogger<OrdersController> logger,
            OrdersService ordersService)
        {
            _logger = logger;
            this.ordersService = ordersService;
        }

        [HttpPost(Name = "create")]
        public async Task<Response<Order>> Create(Order newOrder)
        {
            var order = (await this.ordersService.CreateOrderAsync(newOrder.ToDto())).ToContract();

           return new Response<Order> { Message = ResponseConstants.OrderCreatedSuccessfullyMessage, StatusCode = 200, Value = order };
        }
    }
}