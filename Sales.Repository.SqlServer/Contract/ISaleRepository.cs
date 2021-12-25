using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Contract
{
    public interface ISaleRepository
    {
        List<Entity.Sale.Sale> GetAll();
        List<Entity.Sale.Sale> GetById(Guid id);
        bool Create(List<Entity.Sale.Sale> saleList);
    }
}
