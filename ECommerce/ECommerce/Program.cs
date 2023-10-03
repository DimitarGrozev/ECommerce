using ECommerce.Services;
using ECommerce.Data;
using ECommerce.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ECommerce.Models;

namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ECommerceDbContext>(opt =>
                opt.UseInMemoryDatabase("ECommerceDb"));

            builder.Services.RegisterServices();

            builder.Services.AddControllers()
                .AddOData(options => options
                    .AddRouteComponents("api", GetEdmModel())
                    .Select()
                    .Filter()
                    .OrderBy()
                    .SetMaxTop(20)
                    .Count()
                    .Expand()
                );
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddODataQueryFilter();


            builder.Services.AddHostedService<ScheduledOrderProcessor>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

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