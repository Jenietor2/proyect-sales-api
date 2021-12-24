using Sales.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Interfaces
{
    public interface IProductRepository
    {
        Guid Create(Product product);
        bool Delete(Guid id);
        Product GetId(Guid id);
        IEnumerable<Product> GetAll();
        bool Update(Product product);
    }
}
