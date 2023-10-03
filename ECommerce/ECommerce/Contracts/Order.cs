using System.ComponentModel.DataAnnotations;

namespace ECommerce.Contracts
{
    public class Order
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<OrderItem> OrderItems { get; set; }
    }
}
