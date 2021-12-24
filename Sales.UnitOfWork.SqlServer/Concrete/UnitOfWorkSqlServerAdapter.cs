using Sales.UnitOfWork.SqlServer.Abstratc;
using Sales.UnitOfWork.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Sales.UnitOfWork.SqlServer.Concrete
{
    public class UnitOfWorkSqlServerAdapter : AbstractSqlServer, IUnitOfWorkAdapter
    {
        public SqlConnection _context { get; set; }
        public SqlTransaction _transaction { get; set; }

        public UnitOfWorkSqlServerAdapter(string connectionstring)
        {
            _context = new SqlConnection(connectionstring);
            _context.Open();

            _transaction = _context.BeginTransaction();
        }
        public IUnitOfWorkRepository Repositories => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
