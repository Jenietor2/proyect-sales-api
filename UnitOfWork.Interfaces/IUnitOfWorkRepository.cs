using Sales.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.UnitOfWork.SqlServer.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        public IProductRepository ProductRepository { get;}
    }
}
