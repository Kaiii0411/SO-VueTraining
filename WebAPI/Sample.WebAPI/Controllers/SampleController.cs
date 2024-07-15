using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.WebAPI.Services;
using System.Data;
using VueSPATemplate.Models;

namespace Sample.WebAPI.Controllers
{
    [Route("api/sample")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IDapperService _dapperService;

        public SampleController (IDapperService dapperService) 
        {
            _dapperService = dapperService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Customer> Customers()
        {
            return _dapperService.GetAll<Customer>("spr_Customer_GetAll", null, System.Data.CommandType.StoredProcedure);
        }

        [HttpGet("[action]/{id}")]
        public Customer CustomerGetById(int id) 
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            return _dapperService.Get<Customer>("spr_Customer_GetById", parameters, System.Data.CommandType.StoredProcedure);
        }
    }
}
