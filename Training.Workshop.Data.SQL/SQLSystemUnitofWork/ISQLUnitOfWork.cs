using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.Domain.Entities;
using System.Data.SqlClient;

namespace Training.Workshop.Data.SQL.SQLSystemUnitOfWork
{
    public interface ISQLUnitOfWork : IUnitOfWork
    {
        SqlConnection Connection { get; }
    }
}
