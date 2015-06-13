using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace StackOverflow
{
    public class Database
    {
        protected OracleConnection connection;

        protected void OpenConnection()
        {
            if (connection == null)
            {
                connection = new OracleConnection();
            }
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    this.connection.ConnectionString = "User Id=system;Password=admin;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));";
                    connection.Open();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        protected void CloseConnection()
        {
            connection.Close();
        }
    }
}