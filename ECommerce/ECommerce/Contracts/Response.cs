namespace ECommerce.Contracts
{
    public class Response<T>
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public T Value { get; set; }
    }
}
