using Microsoft.Extensions.Configuration;
using Sales.Business.Sale;
using Sales.Entity.Sale;
using Sales.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Concrete
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SaleBL _saleBL;
        public SaleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _saleBL = new SaleBL(_configuration);
        }
        public bool Create(Sale sales)
        {
            try
            {
                return _saleBL.CreateSale(sales);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Sale GetById(Guid id)
        {
            try
            {
                return _saleBL.GetSalesByCustomerId(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
