using Dapper;
using Sample.WebAPI.Requests;
using System.Data;

namespace Sample.WebAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDapperService _dapperService;

        public OrderService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public bool PlaceOrder(OrderCreateRequest request)
        {
            try
            {
                if (request.Items.Count() == 0)
                    return false;

                DateTime now = DateTime.Now;
                int orderId = 0;

                var parameters = new DynamicParameters();
                parameters.Add("OrderDate", now, DbType.DateTime);
                parameters.Add("OrderNumber", now.Ticks.ToString(), DbType.String);
                parameters.Add("CustomerId", 11, DbType.Int32);
                parameters.Add("TotalAmount", request.TotalAmount, DbType.Decimal);
                orderId = _dapperService.Insert<int>("spr_Order_Create", parameters, CommandType.StoredProcedure);

                if (orderId != 0)
                {
                    foreach (var item in request.Items)
                    {
                        if (item.ProductId == 0)
                            continue;

                        var param = new DynamicParameters();
                        param.Add("OrderId", orderId, DbType.Int32);
                        param.Add("ProductId", item.ProductId, DbType.Int32);
                        param.Add("UnitPrice", item.UnitPrice, DbType.Decimal);
                        param.Add("Quantity", item.Quantity, DbType.Int32);
                        _dapperService.Insert<int>("spr_OrderItem_Create", param, CommandType.StoredProcedure);
                    }

                    return true;
                } 
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
