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

        //public async Task<bool> SetOrderStatus(int orderId, OrderStatus orderStatus)
        //{
        //    var order = await this.dbContext.Orders
        //            .Where(order => order.Id == orderId)
        //            .FirstOrDefaultAsync();

        //    if (order == null)
        //    {
        //        return false;
        //    }

        //    order.Status = orderStatus;

        //    return await this.dbContext.SaveChangesAsync() == 1;
        //}

        public async Task<Response<Models.Order>> CreateOrderAsync(Contracts.Order newOrder)
        {
            //Validate order, payment, etc
            var customer = await this.dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == newOrder.CustomerId);

            if (customer == null)
            {
                return new Response<Models.Order> { StatusCode = 401, Message = "Customer details could not be found."};
            }

            var order = new Models.Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                OrderDate = DateTimeOffset.Now,
                Status = OrderStatus.New
            };

            await this.dbContext.AddAsync(order);

            var items = new List<Models.OrderItem>();
            var productsToRemove = new List<Models.Product>();

            foreach (var requestedProduct in newOrder.OrderItems.Select(item => (Id: item.ProductId, Quantity: item.Quantity)))
            {
                var productStockCount = await this.dbContext.Products.Where(product => product.SKU == requestedProduct.Id).CountAsync();
                
                if (productStockCount < requestedProduct.Quantity)
                {
                    return new Response<Models.Order> { StatusCode = 400, Message = $"Order for item with ID:{requestedProduct.Id} cannot be completed due to insufficient stock." };
                }

                var products = await this.dbContext.Products.Where(product => product.SKU == requestedProduct.Id).Take(requestedProduct.Quantity).ToListAsync();

                items.Add(new Models.OrderItem { ItemPrice = products[0].Price, OrderId = order.Id, ProductId = products[0].SKU, Quantity = requestedProduct.Quantity });
                productsToRemove.AddRange(products);
            }

            await this.dbContext.OrderItems.AddRangeAsync(items);
            this.dbContext.RemoveRange(productsToRemove);

            await this.dbContext.SaveChangesAsync();

            return new Response<Models.Order> { Message = "Order created", StatusCode = 201, Value = order };
        }
    }
}
