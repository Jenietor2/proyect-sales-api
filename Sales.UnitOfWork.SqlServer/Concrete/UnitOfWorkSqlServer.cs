using Microsoft.Extensions.Configuration;
using Sales.UnitOfWork.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.UnitOfWork.SqlServer.Concrete
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        public IUnitOfWorkAdapter Create()
        {
            string connectionstring = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            return new UnitOfWorkSqlServerAdapter(connectionstring);
        }
    }
}
