using ECommerce.Configuration;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ECommerce.Services
{
    public class ScheduledOrderProcessor : BackgroundService
    {
        private readonly ILogger<ScheduledOrderProcessor> _logger;
        private readonly IOptions<ScheduledOrderProcessorConfig> config;
        private readonly IServiceProvider serviceProvider;
        private Timer _timer;

        public ScheduledOrderProcessor(
            ILogger<ScheduledOrderProcessor> logger,
            IOptions<ScheduledOrderProcessorConfig> config,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.config = config;
            this.serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(this.ProcessOrdersBatch, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            stoppingToken.Register(() =>
            {
                _timer.Change(Timeout.Infinite, 0);
            });

            return Task.CompletedTask;
        }

        private async void ProcessOrdersBatch(object state)
        {
            using var scope = this.serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();

            var newOrders = await dbContext.Orders
                    .Include(order => order.OrderItems)
                        .ThenInclude(orderItem => orderItem.Product)
                    .Where(order => order.Status == Models.OrderStatus.New)
                    .ToListAsync();

            if (newOrders.Count == 0)
            {
                _logger.LogInformation($"[{DateTimeOffset.Now}] No orders to process");

                return;
            }


            // Change status to 'Processing' to not overlap with next background task
            newOrders.ForEach(orderWrapper => orderWrapper.Status = Models.OrderStatus.Processing);
            await dbContext.SaveChangesAsync();


            // Start processing orders batch
            foreach (var orderWrapper in newOrders)
            {
                _logger.LogInformation($"[{DateTimeOffset.Now}]Processing order number: {orderWrapper.Id}");
                await Task.Delay(1000);
                orderWrapper.Status = Models.OrderStatus.Shipped;
            }

            await dbContext.SaveChangesAsync();
        }
    }
}