﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL.SQLSystemUnitOfWork
{
    class SQLSystemDatabaseUnitOfWork : ISQLUnitOfWork
    {
        /// <summary>
        /// Connection string to SQL database
        /// </summary>
        private SqlConnection connection;

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }
        /// Constructor
        /// </summary>
        /// <param name="unitofworkfactory"></param>
        public SQLSystemDatabaseUnitOfWork(SQLSystemDatabaseUnitofWorkFactory unitofworkfactory)
        {
            connection = new SqlConnection("Data Source=KOLESNIKOV7;Initial Catalog=Training.Workshop.SQLDatabase;Integrated Security=True;");
            connection.Open();
        }
        /// <summary>
        /// Free all resources and close current Unit of Work.
        /// </summary>
        public void Dispose()
        {
            connection.Close();
            Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork(this);
        }
    }
}
