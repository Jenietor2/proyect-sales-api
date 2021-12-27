using Sales.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetId(Guid id);
        Product Create(Product product);
        Product Update(Product product);
        bool Delete(Guid id);
    }
}
