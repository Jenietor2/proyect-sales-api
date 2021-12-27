using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Entity.Sale;
using Sales.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRespository;
        public SaleController(ISaleRepository saleRepository)
        {
            _saleRespository = saleRepository;
        }

        [HttpPost]
        public IActionResult InsertSale([FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_saleRespository.Create(sale));
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleByCustomerId(Guid id)
        {

            Sale product = _saleRespository.GetById(id);

            return Ok(product);
        }
    }
}
