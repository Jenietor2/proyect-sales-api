using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.UnitOfWork.SqlServer.Interfaces
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        void SaveChanges();
    }
}
