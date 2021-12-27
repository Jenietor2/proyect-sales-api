using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sales.Entity;
using Sales.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRespository;
        private readonly IConfiguration _configuration;
        public ProductController(IProductRepository productRepository, IConfiguration configuration)
        {
            _productRespository = productRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_productRespository.Create(product));
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {


            List<Product> productList = _productRespository.GetAll().ToList();
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {


            Product product = _productRespository.GetId(id);

            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            return Ok(_productRespository.Update(product));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {


            if (_productRespository.Delete(id))
            {
                return Ok("Producto eliminado");
            }
            return NotFound("Producto no encontrado");
        }
    }
}
