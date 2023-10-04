using ECommerce.Data;
using ECommerce.Services;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Net.Http.Headers;

namespace ECommerce.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<OrdersService>();
            services.AddScoped<ECommerceRepo>();
            services.AddScoped<DbSeeder>();

            return services;
        }

        public static void AddODataFormatters(this IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }

    }
}
