using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.WebAPI.Models;
using Sample.WebAPI.Requests;
using Sample.WebAPI.Services;
using System.Data;

namespace Sample.WebAPI.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IDapperService _dapperService;

        public SupplierController(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Supplier> GetAll()
        {
            return _dapperService.GetAll<Supplier>("spr_Supplier_GetAll", null, System.Data.CommandType.StoredProcedure);
        }

        [HttpPost("[action]")]
        public string Update(SupplierUpdateRequest request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", request.Id, DbType.Int32);
                parameters.Add("CompanyName", request.CompanyName, DbType.String);
                parameters.Add("ContactName", request.ContactName, DbType.String);
                parameters.Add("City", request.City, DbType.String);
                parameters.Add("Country", request.Country, DbType.String);
                parameters.Add("Phone", request.Country, DbType.String);

                _dapperService.Update<object>("spr_Supplier_Update", parameters, System.Data.CommandType.StoredProcedure);
                return "Update success!";
            }
            catch (Exception ex)
            {
                return $"Update failed! Error: {ex.Message}";
            }
        }
    }
}
