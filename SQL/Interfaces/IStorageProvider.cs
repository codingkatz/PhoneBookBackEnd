using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.SQL
{
    public interface IStorageProvider<T> where T : class
    {
        object ExecuteScalar(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text);

        Dictionary<string, object> ExecuteNonQuery(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text);

        DataSet ExecuteQuery(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text);

        Task<object> ExecuteScalarAsync(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text);

        Task<Dictionary<string, object>> ExecuteNonQueryAsync(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text);

        Task<DataSet> ExecuteQueryAsync(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text);

        Task<object> BulkCopyAsync(string destinationTableName, DataTable table, Dictionary<string, string> columnMappings, ConnectionType connectionType = ConnectionType.READ);
    }
}
