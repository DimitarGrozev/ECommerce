namespace ECommerce.Contracts
{
    public class OrderItemRequest
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
