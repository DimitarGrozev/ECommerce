namespace ECommerce.Contracts
{
    public class Response<T>
    {
        public bool IsSuccessful { get; set; } = false;

        public string Message { get; set; }

        public T Value { get; set; }
    }
}
