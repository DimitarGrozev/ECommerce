namespace ECommerce.Contracts
{
    public class ResponseConstants
    {
        public const string OrderCreatedSuccessfullyMessage = "The order has been created successfully";
        public const string CustomerDetailsNotFoundMessage = "Customer details could not be found";
        public const string OrderCreatedMessage = "Order created";
        public const string ProductUnavailableMessage = "Product with ID: {0} is no longer available.";
        public const string InsufficientStockForProductMessage = "Order for item with ID:{0} cannot be completed due to insufficient stock.";
    }
}
