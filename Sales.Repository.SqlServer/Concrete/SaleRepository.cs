using Sales.Entity.Sale;
using Sales.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Concrete
{
    public class SaleRepository : ISaleRepository
    {
        public bool Create(List<Sale> salesList)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
