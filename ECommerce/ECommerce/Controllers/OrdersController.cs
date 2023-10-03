using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("odata/orders")]
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

        [EnableQuery(PageSize = 3)]
        [HttpGet]
        public IQueryable<Order> Get()
        {
            return this.repo.GetAll();
        }


        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<Order> Get([FromODataUri] Guid key)
        {
            return SingleResult.Create(this.repo.GetById(key));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contracts.Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderResponse = this.ordersService.CreateOrderAsync(order);

            return Created("companies", orderResponse);
        }
    }
}