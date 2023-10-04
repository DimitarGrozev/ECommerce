using ECommerce.Contracts;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class OrdersService
    {
        private readonly ECommerceDbContext dbContext;

        public OrdersService(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<Models.Order>> CreateOrderAsync(Contracts.CreateOrderRequest newOrder)
        {
            var customer = await this.dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == newOrder.CustomerId);

            if (customer == null)
            {
                return new Response<Models.Order> { Message = ResponseConstants.CustomerDetailsNotFoundMessage };
            }

            var order = this.CreateNewOrder(customer);
            var orderItemCreationResult = await this.TryCreateOrderItems(newOrder);

            if (!string.IsNullOrEmpty(orderItemCreationResult.ErrorMessage))
            {
                return new Response<Models.Order> { Message = orderItemCreationResult.ErrorMessage };
            }

            order.OrderItems = orderItemCreationResult.OrderItems;

            await this.dbContext.Orders.AddAsync(order);
            await this.dbContext.SaveChangesAsync();

            return new Response<Models.Order> { IsSuccessful = true, Message = ResponseConstants.OrderCreatedMessage, Value = order };
        }

        private Models.Order CreateNewOrder(Customer customer)
        {
            return new Models.Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTimeOffset.Now,
                Status = OrderStatus.New
            };
        }

        private async Task<(List<Models.OrderItem> OrderItems, string ErrorMessage)> TryCreateOrderItems(Contracts.CreateOrderRequest newOrder)
        {
            var items = new List<Models.OrderItem>();

            foreach (var requestedProduct in newOrder.OrderItems.Select(item => (Id: item.ProductId, Quantity: item.Quantity)))
            {
                var productInStock = await this.dbContext.Products.FirstOrDefaultAsync(product => product.Id == requestedProduct.Id);

                if (productInStock == null)
                {
                    return (new List<Models.OrderItem>(), string.Format(ResponseConstants.ProductUnavailableMessage, requestedProduct.Id));
                }

                if (productInStock.Quantity < requestedProduct.Quantity)
                {
                    return (new List<Models.OrderItem>(), string.Format(ResponseConstants.InsufficientStockForProductMessage, requestedProduct.Id));
                }

                productInStock.Quantity -= requestedProduct.Quantity;

                items.Add(new Models.OrderItem { ItemPrice = productInStock.Price, ProductId = productInStock.Id, Quantity = requestedProduct.Quantity });
            }

            return (items, string.Empty);
        }
    }
}
