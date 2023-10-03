using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Services.DTOs;
using ECommerce.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class OrdersService
    {
        private readonly ECommerceDbContext dbContext;

        public OrdersService(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<Order>> GetNewOrdersBatchAsync(int batchSize = 1)
        {
            return await this.dbContext.Orders
                    .Where(order => order.Status == OrderStatus.New)
                    .Take(batchSize)
                    .ToListAsync();
        }

        public async Task<bool> SetOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var order = await this.dbContext.Orders
                    .Where(order => order.Id == orderId)
                    .FirstOrDefaultAsync();

            if (order == null)
            {
                return false;
            }

            order.Status = orderStatus;

            return await this.dbContext.SaveChangesAsync() == 1;
        }

        public async Task<OrderDTO> CreateOrderAsync(OrderDTO newOrder)
        {
            //Validate order, payment, etc
            var customer = await this.dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == newOrder.CustomerId);
            var products = await this.dbContext.Products.Where(product => newOrder.OrderItems.Select(item => item.ProductId).Contains(product.Id)).ToListAsync();

            foreach (var requestedProduct in newOrder.OrderItems.Select(item => (Id: item.ProductId, Quantity: item.Quantity)))
            {
                var productStockCount = await this.dbContext.Products.Where(product => product.ProductId == requestedProduct.Id).CountAsync();
                
                if (productStockCount! > requestedProduct.Quantity)
                {
                }
            }
            var order = await this.dbContext.Orders.AddAsync(new Order());

            return order.Entity.ToDto();
        }
    }
}
