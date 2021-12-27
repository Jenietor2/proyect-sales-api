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
        public Sales.Entity.Product CreateProduct(Sales.Entity.Product product)
        {
            Guid id = productDAL.InsertProduct(product);
            return GetProductById(id);
        }

        public Sales.Entity.Product UpdateProduct(Sales.Entity.Product product)
        {
           productDAL.UpdateProduct(product);
           
            return GetProductById(product.Id);
        }
        public bool DeleteProduct(Guid id)
        {
            return productDAL.DeleteProductById(id);
        }

    }
}
