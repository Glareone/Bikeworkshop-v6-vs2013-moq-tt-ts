using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.Data.SQL.SQLSystemUnitOfWork
{
    public class SQLSystemDatabaseUnitofWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new SQLSystemDatabaseUnitOfWork(this);
        }
    }
}
