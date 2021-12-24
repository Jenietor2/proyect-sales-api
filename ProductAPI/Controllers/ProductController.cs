using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Data.Product;
using Sales.Entity;
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
        [HttpPost]
        public IActionResult InsertProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductDAL productDAL = new ProductDAL();

            productDAL.InsertProduct(product);
            return StatusCode(200);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            ProductDAL productDAL = new ProductDAL();

            List<Product> productList = productDAL.GetProducts();
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            ProductDAL productDAL = new ProductDAL();

            Product product = productDAL.GetProductById(id);

            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            ProductDAL productDAL = new ProductDAL();
            
            if (productDAL.UpdateProduct(product))
            {
                return Ok("Actualización satisfactoria");
            }

            return NotFound("Producto no encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            ProductDAL productDAL = new ProductDAL();

            if (productDAL.DeleteProductById(id))
            {
                return Ok("Producto eliminado");
            }
            return NotFound("Producto no encontrado");
        }
    }
}
