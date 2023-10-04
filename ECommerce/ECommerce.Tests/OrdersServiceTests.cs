using ECommerce.Contracts;
using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Tests
{
    [TestFixture]
    public class OrdersServiceTests
    {
        private DbContextOptions<ECommerceDbContext> dbContextOptions;
        private ECommerceDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContextOptions = new DbContextOptionsBuilder<ECommerceDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            dbContext = new ECommerceDbContext(dbContextOptions);

            await dbContext.Products.AddRangeAsync(new List<Product>
            {
                   new Product { Name = "Laptop", Description = "Description A", Price = 1999.99m, Quantity = 10 },
                   new Product { Name = "Phone", Description = "Description B", Price = 719.99m, Quantity = 10 },
                   new Product { Name = "TV", Description = "Description C", Price = 2659.99m , Quantity = 10 },
                   new Product { Name = "Fridge", Description = "Description D", Price = 1229.99m, Quantity = 10 },
                   new Product { Name = "Oven", Description = "Description E", Price = 700.99m, Quantity = 10 }
            });

            await dbContext.Customers.AddRangeAsync(new List<Customer>
            {
                   new Customer { FirstName = "John", LastName = "Doe", Email = "john@example.com", Address = "1700 Sofia, Ivan Asen 2 Bulgaria", Phone = "0800123123" },
                   new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Address = "3222 Sofia, Svetata Troica 3 Bulgaria", Phone = "08123123123" }
            });

            await dbContext.SaveChangesAsync();

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public async Task CreateOrderAsync_ValidOrder_ReturnsSuccessfulResponse()
        {
            // Arrange
            var ordersService = new OrdersService(dbContext);

            var newOrder = new Contracts.CreateOrderRequest
            {
                CustomerId = 1,
                OrderItems = new List<Contracts.OrderItemRequest> 
                {
                    new Contracts.OrderItemRequest { ProductId = 1, Quantity = 1 }
                }
            };

            // Act
            var response = await ordersService.CreateOrderAsync(newOrder);

            // Assert
            Assert.True(response.IsSuccessful);
            Assert.That(ResponseConstants.OrderCreatedMessage == response.Message);
        }

        [Test]
        public async Task CreateOrderAsync_InvalidCustomer_ReturnsUnsuccessfulResponse()
        {
            // Arrange
            var ordersService = new OrdersService(dbContext);

            var newOrder = new Contracts.CreateOrderRequest
            {
                CustomerId = 1123,
                OrderItems = new List<Contracts.OrderItemRequest> 
                {
                    new Contracts.OrderItemRequest { ProductId = 1, Quantity = 1 }
                }
            };

            // Act
            var response = await ordersService.CreateOrderAsync(newOrder);

            // Assert
            Assert.False(response.IsSuccessful);
            Assert.That(ResponseConstants.CustomerDetailsNotFoundMessage == response.Message);
        }


        [Test]
        public async Task CreateOrderAsync_ProductUnavailable_ReturnsUnsuccessfulResponse()
        {
            // Arrange
            var ordersService = new OrdersService(dbContext);

            var newOrder = new Contracts.CreateOrderRequest
            {
                CustomerId = 1,
                OrderItems = new List<Contracts.OrderItemRequest> 
                {
                    new Contracts.OrderItemRequest { ProductId = 1123, Quantity = 1 }
                }
            };

            // Act
            var response = await ordersService.CreateOrderAsync(newOrder);

            // Assert
            Assert.False(response.IsSuccessful);
            Assert.That(string.Format(ResponseConstants.ProductUnavailableMessage, 1123) == response.Message);
        }

        [Test]
        public async Task CreateOrderAsync_InsufficientProductStock_ReturnsUnsuccessfulResponse()
        {
            // Arrange
            var ordersService = new OrdersService(dbContext);

            var newOrder = new Contracts.CreateOrderRequest
            {
                CustomerId = 1,
                OrderItems = new List<Contracts.OrderItemRequest> 
                {
                    new Contracts.OrderItemRequest { ProductId = 1, Quantity = 11 }
                }
            };

            // Act
            var response = await ordersService.CreateOrderAsync(newOrder);

            // Assert
            Assert.False(response.IsSuccessful);
            Assert.That(string.Format(ResponseConstants.InsufficientStockForProductMessage, 1) == response.Message);
        }
    }
}
