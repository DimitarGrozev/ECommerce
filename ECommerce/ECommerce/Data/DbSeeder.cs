using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class DbSeeder
    {
        private readonly ECommerceDbContext dbContext;

        public DbSeeder(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SeedData()
        {
            this.dbContext.Customers.AddRange(
                    new Customer { FirstName = "John", LastName = "Doe", Email = "john@example.com", Address = "1700 Sofia, Ivan Asen 2 Bulgaria", Phone = "0800123123" },
                    new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Address = "3222 Sofia, Svetata Troica 3 Bulgaria", Phone = "08123123123" });

            var products = new List<Product>
            {
                    new Product { Name = "Laptop", Description = "Description A", Price = 1999.99m, Quantity = 10 },
                    new Product { Name = "Phone", Description = "Description B", Price = 719.99m, Quantity = 10 },
                    new Product { Name = "TV", Description = "Description C", Price = 2659.99m , Quantity = 10 },
                    new Product { Name = "Fridge", Description = "Description D", Price = 1229.99m, Quantity = 10 },
                    new Product { Name = "Oven", Description = "Description E", Price = 700.99m, Quantity = 10 }
            };

            //foreach (var product in await this.dbContext.Products.ToListAsync())
            //{
            //    if (product.Quantity < 10)
            //    {
            //        product.Quantity = 10;
            //    }
            //}

            await this.dbContext.Products.AddRangeAsync(products);

            await this.dbContext.SaveChangesAsync();
        }

    }
}
