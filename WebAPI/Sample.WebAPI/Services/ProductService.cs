using Dapper;
using Sample.WebAPI.Models;
using System.Data;
using VueSPATemplate.Models;

namespace Sample.WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IDapperService _dapperService;

        public ProductService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public IEnumerable<Product> GetProductsBySupplier(int supplierId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("SupplierId", supplierId, DbType.Int32);

            return _dapperService.GetAll<Product>("spr_Product_GetBySupplier", parameters, System.Data.CommandType.StoredProcedure);
        }

        public Product GetProductDetails(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            return _dapperService.Get<Product>("spr_Product_GetById", parameters, System.Data.CommandType.StoredProcedure);
        }
    }
}
