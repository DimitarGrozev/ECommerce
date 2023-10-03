using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce.Services
{
    public class ScheduledOrderProcessor : BackgroundService
    {
        private static int orderNumber = 0;
        private readonly ILogger<ScheduledOrderProcessor> _logger;
        private Timer _timer;

        public ScheduledOrderProcessor(ILogger<ScheduledOrderProcessor> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(this.ProcessOrders, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            stoppingToken.Register(() =>
            {
                _timer.Change(Timeout.Infinite, 0);
            });
            
            return Task.CompletedTask;
        }

        private void ProcessOrders(object state)
        {
            _logger.LogInformation($"Processing order number: {orderNumber++} at " + DateTime.Now);
        }
    }
}