using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.WebAPI.Requests;
using Sample.WebAPI.Services;

namespace Sample.WebAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost("[action]")]
        public bool PlaceOrder(OrderCreateRequest request)
        {
            try
            {
                return _orderService.PlaceOrder(request);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
