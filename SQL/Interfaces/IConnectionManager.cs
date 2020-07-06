using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.SQL.Interfaces
{
    public interface IConnectionManager
    {
        ISQLOptions Settings { get; set; }
        SqlConnection EstablishConnection(ConnectionType ConnectionType = ConnectionType.READ, string ConnectionString = null);
        void ReEstablishConnection();
        void Dispose();
    }
}
