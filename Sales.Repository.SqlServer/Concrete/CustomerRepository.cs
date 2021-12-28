using Microsoft.Extensions.Configuration;
using Sales.Business.Customer;
using Sales.Entity.Customer;
using Sales.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly CustomerBL _customerBL;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _customerBL = new CustomerBL(_configuration);
        }

        public Guid Create(Customer customer)
        {
            try
            {
                return _customerBL.CreateCustomer(customer);
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
                return _customerBL.DeleteCustomer(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return _customerBL.GetAllCustomers();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Customer GetId(Guid id)
        {
            try
            {
                return _customerBL.GetCustomerById(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Customer Update(Customer customer)
        {
            try
            {
                return _customerBL.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
