using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sales.Entity.Customer;
using Sales.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRespository;
        private readonly IConfiguration _configuration;
        public CustomerController(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRespository = customerRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] Customer product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_customerRespository.Create(product));
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {


            List<Customer> customerList = _customerRespository.GetAll();
            return Ok(customerList);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {


            Customer customer = _customerRespository.GetId(id);

            return Ok(customer);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Customer customer)
        {
            return Ok(_customerRespository.Update(customer));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {


            if (_customerRespository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
