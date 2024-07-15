using Sample.WebAPI.Models;

namespace Sample.WebAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsBySupplier(int supplierId);
        Product GetProductDetails(int id);
    }
}
