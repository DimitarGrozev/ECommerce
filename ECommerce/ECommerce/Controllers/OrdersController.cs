using ECommerce.Contracts;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly OrdersService ordersService;
        private readonly ECommerceRepo repo;

        public OrdersController(
            ILogger<OrdersController> logger,
            OrdersService ordersService,
            ECommerceRepo repo)
        {
            _logger = logger;
            this.ordersService = ordersService;
            this.repo = repo;
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable<Models.Order> Get()
        {
            return this.repo.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Response<Models.Order>>> Post([FromBody] CreateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderResponse = await this.ordersService.CreateOrderAsync(order);

            if (!orderResponse.IsSuccessful)
            {
                return BadRequest(orderResponse);
            }

            return Created($"api/orders/{orderResponse.Value.Id}", orderResponse);
        }
    }
}