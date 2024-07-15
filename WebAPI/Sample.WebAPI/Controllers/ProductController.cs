using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.WebAPI.Models;
using Sample.WebAPI.Services;

namespace Sample.WebAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService  _productService;

        public ProductController (IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]/{supplierId}")]
        public IEnumerable<Product> GetProductsBySupplier(int supplierId)
        {
            return _productService.GetProductsBySupplier(supplierId);
        }

        [HttpGet("[action]/{id}")]
        public Product GetById(int id) 
        {
            return _productService.GetProductDetails(id);
        }
    }
}
