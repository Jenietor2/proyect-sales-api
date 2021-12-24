using Microsoft.Extensions.Configuration;
using Sales.Data.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Business.Product
{
    public class ProductBL
    {
        private readonly ProductDAL productDAL;
        private readonly IConfiguration _configuration;

        public ProductBL(IConfiguration configuration)
        {
            _configuration = configuration;
            productDAL = new ProductDAL(_configuration);
        }

        public List<Sales.Entity.Product> GetAllProducts()
        {
            return productDAL.GetProducts();
        }

        public Sales.Entity.Product GetProductById(Guid id)
        {
            return productDAL.GetProductById(id);
        }
        public Guid CreateProduct(Object product)
        {
            return productDAL.InsertProduct((Sales.Entity.Product)product);
        }

        public bool UpdateProduct(Object product)
        {
            return productDAL.UpdateProduct((Sales.Entity.Product)product);
        }
        public bool DeleteProduct(Guid id)
        {
            return productDAL.DeleteProductById(id);
        }

    }
}
