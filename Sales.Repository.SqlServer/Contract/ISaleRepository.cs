using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Contract
{
    public interface ISaleRepository
    {
        //List<Entity.Sale.Sale> GetAll();
        Entity.Sale.Sale GetById(Guid id);
        bool Create(Entity.Sale.Sale sale);
    }
}
