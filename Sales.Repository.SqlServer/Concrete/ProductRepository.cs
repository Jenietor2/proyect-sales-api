using Microsoft.Extensions.Configuration;
using Sales.Business.Customer;
using Sales.Business.Product;
using Sales.Entity;
using Sales.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Sales.Repository.SqlServer.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ProductBL _productBL;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _productBL = new ProductBL(_configuration);
        }

        public Guid Create(Product product)
        {
            try
            {
                return _productBL.CreateProduct(product);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public bool Delete(Guid id)
        {
            try
            {
                return _productBL.DeleteProduct(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                return _productBL.GetAllProducts();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetId(Guid id)
        {
            try
            {
                return _productBL.GetProductById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Product product)
        {
            try
            {
                return _productBL.UpdateProduct(product);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
