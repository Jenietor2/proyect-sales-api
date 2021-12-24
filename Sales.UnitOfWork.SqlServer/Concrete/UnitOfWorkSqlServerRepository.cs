using Sales.Repository.Interfaces;
using Sales.UnitOfWork.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Sales.Repository.SqlServer.Concrete;

namespace Sales.UnitOfWork.SqlServer.Concrete
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IProductRepository ProductRepository { get; }
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            //ProductRepository = new ProductReporsitory(context, transaction);
        }

    }
}
