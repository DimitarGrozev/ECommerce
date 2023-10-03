using ECommerce.Models;
using ECommerce.Services.DTOs;

namespace ECommerce.Services.Mappers
{
    public static class OrdersMapper
    {
        public static OrderDTO ToDto(this Order order)
        {
            return new OrderDTO
            {
                CustomerId = order.CustomerId,
                OrderItems = order.OrderItems.ToDto()
            };
        }

        public static OrderItemDTO ToDto(this OrderItem order)
        {
            return new OrderItemDTO
            {
                ProductId = order.ProductId,
                Quantity = order.Quantity,
            };
        }

        public static List<OrderItemDTO> ToDto(this List<OrderItem> orders)
        {
           return orders.Select(ToDto).ToList();
        }
    }
}
