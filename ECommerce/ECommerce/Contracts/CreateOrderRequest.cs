using System.ComponentModel.DataAnnotations;

namespace ECommerce.Contracts
{
    public class CreateOrderRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<OrderItemRequest> OrderItems { get; set; }
    }
}
