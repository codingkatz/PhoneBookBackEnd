using Microsoft.Data.SqlClient;
using phonebookCollectionService.SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.SQL
{
    public class ConnectionManager : IConnectionManager
    {
        public ISQLOptions Settings { get; set; }

        public ConnectionManager(ISQLOptions settings)
        {
            Settings = settings;
        }

        private SqlConnection conn;

        public SqlConnection Connection
        {
            get
            {
                if (conn == null)
                {
                    conn = EstablishConnection();
                }

                return conn;
            }
        }

        public void Dispose()
        {
            if (conn != null)
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        public SqlConnection EstablishConnection(ConnectionType ConnectionType = ConnectionType.READ, string ConnectionString = null)
        {
            try
            {
                ConnectionStringSettings connString;

                if (ConnectionString == null)
                {
                    connString = new ConnectionStringSettings();
                    connString.ConnectionString = "Server=tcp:pafelaserver.database.windows.net,1433;Initial Catalog=PafelaDB;Persist Security Info=False;User ID=Katlego;Password=123*()ZXC<>?qwe;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                }
                else
                    connString = new ConnectionStringSettings("ConnectionString", ConnectionString);

                if (connString == null)
                    throw new ApplicationException("No ConnectionString found. You cannot use this library without this setting in your app/web.config.");

                return new SqlConnection(connString.ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReEstablishConnection()
        {
            conn = EstablishConnection();
        }
    }
}
