using ECommerce.Services;
using ECommerce.Data;
using ECommerce.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ECommerce.Models;
using System.Text.Json.Serialization;
using ECommerce.Configuration;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Net.Http.Headers;

namespace ECommerce
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ECommerceDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            builder.Services.RegisterServices();

            builder.Services.AddControllers()
                .AddOData(options => options
                    .Select()
                    .Filter()
                    .OrderBy()
                    .Count()
                    .Expand()
                )
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            builder.Services.Configure<ScheduledOrderProcessorConfig>(builder.Configuration.GetSection("ScheduledOrderProcessorConfig"));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddODataFormatters();

            builder.Services.AddHostedService<ScheduledOrderProcessor>();

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ECommerceDbContext>();

            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.Database.MigrateAsync();

            var dbSeeder = scope.ServiceProvider.GetService<DbSeeder>();
            await dbSeeder.SeedData();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.Run();
        }

        static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<Order>("Orders");
            return builder.GetEdmModel();
        }
    }
}