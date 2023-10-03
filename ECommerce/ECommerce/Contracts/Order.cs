namespace ECommerce.Contracts
{
    public class Order
    {
        public int CustomerId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
