using ECommerce.Contracts;
using ECommerce.Services.DTOs;

namespace ECommerce.Utilities.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO ToDto(this Order order)
        {
            return new OrderDTO
            {
                CustomerId = order.CustomerId,
                OrderItems = order.OrderItems.ToDto()
            };
        }

        public static OrderItemDTO ToDto(this OrderItem orderItem)
        {
            return new OrderItemDTO
            {
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
            };
        }

        public static Order ToContract(this OrderDTO order)
        {
            return new Order
            {
                CustomerId = order.CustomerId,
                OrderItems = order.OrderItems.ToContract()
            };
        }

        public static OrderItem ToContract(this OrderItemDTO orderItem)
        {
            return new OrderItem
            {
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
            };
        }

        public static List<OrderItemDTO> ToDto(this List<OrderItem> orderItems) 
        { 
            return orderItems.Select(ToDto).ToList();
        }

        public static List<OrderItem> ToContract(this List<OrderItemDTO> orderItems)
        {
            return orderItems.Select(ToContract).ToList();
        }
    }
}
