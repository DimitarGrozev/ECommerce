using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class ECommerceRepo
    {
        private readonly ECommerceDbContext _context;

        public ECommerceRepo(ECommerceDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders
                    //.Include(order => order.OrderItems)
                        .AsQueryable();
        }

        public IQueryable<Order> GetById(Guid id)
        {
            return _context.Orders
                .Where(order => order.Id == id)
                .Include(a => a.OrderItems)
                .AsQueryable();
        }

        public async Task Create(Order order)
        {
            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }
    }
}
