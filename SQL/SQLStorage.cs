using Microsoft.Data.SqlClient;
using phonebookCollectionService.SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.SQL
{
    public class SQLStorage : IStorageProvider<SQLStorage>
    {
        private IConnectionManager ConnectionManager;

        public SQLStorage(IConnectionManager connectionManager)
        {
            ConnectionManager = connectionManager;
        }

        /// <summary>
        /// Executes a SQL Statement or SQL Procedure
        /// </summary>
        /// <param name="query">The SQL Statement OR the SQL Stored Procedure</param>
        /// <param name="inputParameterList">List of Input Parameters</param>
        /// <param name="outputParameterList">List of Output Parameters</param>
        /// <param name="returnParameter">The name of the return parameter</param>
        /// <param name="commandType">Specify the CommandType</param>
        /// <returns>Returns a Dictionary with the list of Output Parameters and their values</returns>
        public Dictionary<string, object> ExecuteNonQuery(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text)
        {
            using (SqlConnection connection = ConnectionManager.EstablishConnection(connectionType))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = commandType.Value;
                    command.CommandTimeout = connectionType == ConnectionType.WRITE ? ConnectionManager.Settings.WriteCommandTimeout : ConnectionManager.Settings.ReadCommandTimeout;

                    foreach (var parameter in inputParameterList)
                    {
                        var param = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };

                        if (parameter.Size.HasValue)
                            param.Size = parameter.Size.Value;

                        if (parameter.Precision.HasValue)
                            param.Precision = parameter.Precision.Value;

                        if (parameter.Scale.HasValue)
                            param.Scale = parameter.Scale.Value;

                        command.Parameters.Add(param);
                    }

                    var resultedOutputParameters = new List<SqlParameter>();

                    foreach (var parameter in outputParameterList)
                    {
                        var outputParameter = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };
                        outputParameter.Direction = ParameterDirection.Output;

                        if (parameter.Size.HasValue)
                            outputParameter.Size = parameter.Size.Value;

                        resultedOutputParameters.Add(outputParameter);
                        command.Parameters.Add(outputParameter);
                    }

                    var returnParam = new SqlParameter(returnParameter, SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(returnParam);

                    command.ExecuteNonQuery();

                    var results = new Dictionary<string, object>();

                    // Check the ReturnValue
                    foreach (var output in resultedOutputParameters)
                    {
                        results.Add(output.ParameterName, output.Value);
                    }

                    return results;
                }
            }
        }

        public async Task<Dictionary<string, object>> ExecuteNonQueryAsync(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text)
        {
            using (SqlConnection connection = ConnectionManager.EstablishConnection(connectionType))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = commandType.Value;
                    command.CommandTimeout = connectionType == ConnectionType.WRITE ? ConnectionManager.Settings.WriteCommandTimeout : ConnectionManager.Settings.ReadCommandTimeout;

                    foreach (var parameter in inputParameterList)
                    {
                        var param = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };

                        if (parameter.Size.HasValue)
                            param.Size = parameter.Size.Value;

                        if (parameter.Precision.HasValue)
                            param.Precision = parameter.Precision.Value;

                        if (parameter.Scale.HasValue)
                            param.Scale = parameter.Scale.Value;

                        command.Parameters.Add(param);
                    }

                    var resultedOutputParameters = new List<SqlParameter>();

                    foreach (var parameter in outputParameterList)
                    {
                        var outputParameter = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };
                        outputParameter.Direction = ParameterDirection.Output;

                        if (parameter.Size.HasValue)
                            outputParameter.Size = parameter.Size.Value;

                        resultedOutputParameters.Add(outputParameter);
                        command.Parameters.Add(outputParameter);
                    }

                    var returnParam = new SqlParameter(returnParameter, SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(returnParam);

                    await command.ExecuteNonQueryAsync();

                    var results = new Dictionary<string, object>();

                    // Check the ReturnValue
                    foreach (var output in resultedOutputParameters)
                    {
                        results.Add(output.ParameterName, output.Value);
                    }

                    return results;
                }
            }
        }

        /// <summary>
        /// Executes a SQL Statement or SQL Procedure
        /// </summary>
        /// <param name="query">The SQL Statement OR the SQL Stored Procedure</param>
        /// <param name="inputParameterList">List of Input Parameters</param>
        /// <param name="outputParameterList">List of Output Parameters</param>
        /// <param name="returnParameter">The name of the return parameter</param>
        /// <param name="commandType">Specify the CommandType</param>
        /// <returns>Returns a DataSet containing the results from the SQL Statement or Stored Procedure</returns>
        public DataSet ExecuteQuery(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text)
        {
            using (SqlConnection connection = ConnectionManager.EstablishConnection(connectionType))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = commandType.Value;
                    command.CommandTimeout = connectionType == ConnectionType.WRITE ? ConnectionManager.Settings.WriteCommandTimeout : ConnectionManager.Settings.ReadCommandTimeout;

                    foreach (var parameter in inputParameterList)
                    {
                        var param = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };

                        if (parameter.Size.HasValue)
                            param.Size = parameter.Size.Value;

                        if (parameter.Precision.HasValue)
                            param.Precision = parameter.Precision.Value;

                        if (parameter.Scale.HasValue)
                            param.Scale = parameter.Scale.Value;

                        command.Parameters.Add(param);
                    }

                    var resultedOutputParameters = new List<SqlParameter>();

                    foreach (var parameter in outputParameterList)
                    {
                        var outputParameter = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };
                        outputParameter.Direction = ParameterDirection.Output;

                        if (parameter.Size.HasValue)
                            outputParameter.Size = parameter.Size.Value;

                        resultedOutputParameters.Add(outputParameter);
                        command.Parameters.Add(outputParameter);
                    }

                    var returnParam = new SqlParameter(returnParameter, SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(returnParam);

                    DataSet dataSet = new DataSet();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataSet);

                        if ((int)returnParam.Value != 0)
                            return null;

                        if (dataSet.Tables.Count > 1)
                        {
                            for (int i = 1; i < dataSet.Tables.Count; i++)
                            {
                                dataSet.Tables[0].Merge(dataSet.Tables[i]);
                            }
                        }
                    }

                    return dataSet;
                }
            }
        }

        public async Task<DataSet> ExecuteQueryAsync(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text)
        {
            using (SqlConnection connection = ConnectionManager.EstablishConnection(connectionType))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = commandType.Value;
                    command.CommandTimeout = connectionType == ConnectionType.WRITE ? ConnectionManager.Settings.WriteCommandTimeout : ConnectionManager.Settings.ReadCommandTimeout;

                    foreach (var parameter in inputParameterList)
                    {
                        var param = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };

                        if (parameter.Size.HasValue)
                            param.Size = parameter.Size.Value;

                        if (parameter.Precision.HasValue)
                            param.Precision = parameter.Precision.Value;

                        if (parameter.Scale.HasValue)
                            param.Scale = parameter.Scale.Value;

                        command.Parameters.Add(param);
                    }

                    var resultedOutputParameters = new List<SqlParameter>();

                    foreach (var parameter in outputParameterList)
                    {
                        var outputParameter = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };
                        outputParameter.Direction = ParameterDirection.Output;

                        if (parameter.Size.HasValue)
                            outputParameter.Size = parameter.Size.Value;

                        resultedOutputParameters.Add(outputParameter);
                        command.Parameters.Add(outputParameter);
                    }

                    var returnParam = new SqlParameter(returnParameter, SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(returnParam);

                    DataSet dataSet = new DataSet();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        dataSet = await Task.Run(() =>
                        {
                            DataSet _dataSet = new DataSet();
                            adapter.Fill(_dataSet);
                            return _dataSet;
                        });

                        if ((int)returnParam.Value != 0)
                            return null;

                        if (dataSet.Tables.Count > 1)
                        {
                            for (int i = 1; i < dataSet.Tables.Count; i++)
                            {
                                dataSet.Tables[0].Merge(dataSet.Tables[i]);
                            }
                        }
                    }

                    return dataSet;
                }
            }
        }

        /// <summary>
        /// Executes a SQL Statement or SQL Procedure
        /// </summary>
        /// <param name="query">The SQL Statement OR the SQL Stored Procedure</param>
        /// <param name="inputParameterList">List of Input Parameters</param>
        /// <param name="outputParameterList">List of Output Parameters</param>
        /// <param name="returnParameter">The name of the return parameter</param>
        /// <param name="commandType">Specify the CommandType</param>
        /// <returns>Returns the value of the First Row, and First Column of the results</returns>
        public object ExecuteScalar(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text)
        {
            using (SqlConnection connection = ConnectionManager.EstablishConnection(connectionType))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = commandType.Value;
                    command.CommandTimeout = connectionType == ConnectionType.WRITE ? ConnectionManager.Settings.WriteCommandTimeout : ConnectionManager.Settings.ReadCommandTimeout;

                    foreach (var parameter in inputParameterList)
                    {
                        var param = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };

                        if (parameter.Size.HasValue)
                            param.Size = parameter.Size.Value;

                        if (parameter.Precision.HasValue)
                            param.Precision = parameter.Precision.Value;

                        if (parameter.Scale.HasValue)
                            param.Scale = parameter.Scale.Value;

                        command.Parameters.Add(param);
                    }

                    var resultedOutputParameters = new List<SqlParameter>();

                    foreach (var parameter in outputParameterList)
                    {
                        var outputParameter = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };
                        outputParameter.Direction = ParameterDirection.Output;

                        if (parameter.Size.HasValue)
                            outputParameter.Size = parameter.Size.Value;

                        resultedOutputParameters.Add(outputParameter);
                        command.Parameters.Add(outputParameter);
                    }

                    var returnParam = new SqlParameter(returnParameter, SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(returnParam);

                    object result = command.ExecuteScalar();

                    return result;
                }
            }
        }

        public async Task<object> ExecuteScalarAsync(string query, List<StorageProviderParameter> inputParameterList, List<StorageProviderParameter> outputParameterList, string returnParameter, ConnectionType connectionType = ConnectionType.READ, CommandType? commandType = CommandType.Text)
        {
            using (SqlConnection connection = ConnectionManager.EstablishConnection(connectionType))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = commandType.Value;
                    command.CommandTimeout = connectionType == ConnectionType.WRITE ? ConnectionManager.Settings.WriteCommandTimeout : ConnectionManager.Settings.ReadCommandTimeout;

                    foreach (var parameter in inputParameterList)
                    {
                        var param = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };

                        if (parameter.Size.HasValue)
                            param.Size = parameter.Size.Value;

                        if (parameter.Precision.HasValue)
                            param.Precision = parameter.Precision.Value;

                        if (parameter.Scale.HasValue)
                            param.Scale = parameter.Scale.Value;

                        command.Parameters.Add(param);
                    }

                    var resultedOutputParameters = new List<SqlParameter>();

                    foreach (var parameter in outputParameterList)
                    {
                        var outputParameter = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.ParameterValue };
                        outputParameter.Direction = ParameterDirection.Output;

                        if (parameter.Size.HasValue)
                            outputParameter.Size = parameter.Size.Value;

                        resultedOutputParameters.Add(outputParameter);
                        command.Parameters.Add(outputParameter);
                    }

                    var returnParam = new SqlParameter(returnParameter, SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(returnParam);

                    object result = await command.ExecuteScalarAsync();

                    return result;
                }
            }
        }

        /// <summary>
        /// Executes the bulk copy function
        /// </summary>
        /// <param name="destinationTableName"></param>
        /// <param name="table"></param>
        /// <param name="columnMappings"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        public async Task<object> BulkCopyAsync(string destinationTableName, DataTable table, Dictionary<string, string> columnMappings, ConnectionType connectionType = ConnectionType.READ)
        {
            var connectionString = connectionType == ConnectionType.WRITE ? ConnectionManager.Settings.WriteConnectionString : ConnectionManager.Settings.ReadConnectionString;
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.FireTriggers))
            {
                sqlBulkCopy.DestinationTableName = destinationTableName;

                foreach (var item in columnMappings)
                {
                    sqlBulkCopy.ColumnMappings.Add(item.Key, item.Value);
                }

                await sqlBulkCopy.WriteToServerAsync(table);
            }

            return true;
        }
    }
}
