using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.UnitOfWork.SqlServer.Abstratc
{
    public abstract class AbstractSqlServer
    {
        protected static string defaultConnectionString = "Data Source=DESKTOP-5PLC5LP;Initial Catalog=Ventas;Integrated Security=True";
    }
}
