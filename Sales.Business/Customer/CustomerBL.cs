using Microsoft.Extensions.Configuration;
using Sales.Data.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Business.Customer
{
    public class CustomerBL
    {
        private readonly CustomerDAL customerDAL;
        private readonly IConfiguration _configuration;

        public CustomerBL(IConfiguration configuration)
        {
            _configuration = configuration;
            customerDAL = new CustomerDAL(_configuration);
        }

        public List<Sales.Entity.Customer.Customer> GetAllCustomers()
        {
            return customerDAL.GetAll();
        }

        public Sales.Entity.Customer.Customer GetCustomerById(Guid id)
        {
            return customerDAL.GetById(id);
        }
        public Guid CreateCustomer(Sales.Entity.Customer.Customer customer)
        {
            return customerDAL.Create(customer);
        }

        public Entity.Customer.Customer UpdateCustomer(Entity.Customer.Customer customer)
        {
            Guid id = customerDAL.Update(customer);
            return GetCustomerById(id);
        }
        public bool DeleteCustomer(Guid id)
        {
            return customerDAL.Delete(id);
        }
    }
}
