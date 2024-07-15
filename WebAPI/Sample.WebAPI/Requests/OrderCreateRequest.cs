namespace Sample.WebAPI.Requests
{
    public class OrderCreateRequest
    {
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemCreateRequest> Items { get; set; }
    }
}
