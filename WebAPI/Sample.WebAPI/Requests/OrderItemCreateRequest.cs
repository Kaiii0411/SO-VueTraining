namespace Sample.WebAPI.Requests
{
    public class OrderItemCreateRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
