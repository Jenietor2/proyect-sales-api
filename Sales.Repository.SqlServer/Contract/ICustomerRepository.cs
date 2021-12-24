using Sales.Entity.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Contract
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetId(Guid id);
        Guid Create(Customer product);
        bool Update(Customer product);
        bool Delete(Guid id);
    }
}
