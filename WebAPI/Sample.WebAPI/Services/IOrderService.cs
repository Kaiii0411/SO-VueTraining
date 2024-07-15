using Sample.WebAPI.Requests;

namespace Sample.WebAPI.Services
{
    public interface IOrderService
    {
        bool PlaceOrder(OrderCreateRequest request);
    }
}
