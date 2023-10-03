using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", Address = "1700 Sofia, Ivan Asen 2 Bulgaria", Phone = "0800123123" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Address = "3222 Sofia, Svetata Troica 3 Bulgaria", Phone = "08123123123" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 1, Name = "Laptop", Description = "Description A", Price = 1999.99m },
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m},
                new Product { Id = 2, Name = "Phone", Description = "Description B", Price = 719.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 3, Name = "TV", Description = "Description C", Price = 2659.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 4, Name = "Fridge", Description = "Description D", Price = 1229.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m },
                new Product { Id = 5, Name = "Oven", Description = "Description E", Price = 700.99m }
            );
        }
    }
}
