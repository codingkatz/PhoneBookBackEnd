using phonebookCollectionService.Models;
using phonebookCollectionService.Repositories.Interfaces;
using phonebookCollectionService.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace phonebookCollectionService.Repositories
{
    public class EntriesRepository : IEntriesRepository
    {
        private readonly IStorageProvider<SQLStorage> _storageProvider;
        public EntriesRepository(IStorageProvider<SQLStorage> storageProvider)
        {
            _storageProvider = storageProvider;
        }
        public async Task<List<Entry>> GetAllEntries()
        {
            try
            {
                var sqlQuery = File.ReadAllText(AppContext.BaseDirectory + "SQL/GetAllEntries.sql");
                string returnParameter = string.Empty;
                List<StorageProviderParameter> parameters = new List<StorageProviderParameter>();
                DataSet dataSet = await _storageProvider.ExecuteQueryAsync(sqlQuery, parameters, new List<StorageProviderParameter>(), returnParameter, ConnectionType.READ, CommandType.Text);

                List<Entry> entries = new List<Entry>();
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        var entry = new Entry
                        {
                            EntryID = Guid.Parse(row["EntryID"].ToString()),
                            Name = row["Name"].ToString(),
                            Phonenumber = row["Phonenumber"].ToString()
                        };
                        entries.Add(entry);
                    }
                    return entries;
                }
                return entries;
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }

        public async Task<string> SaveEntry(string name, string phonenumber)
        {
            try
            {
                var sqlQuery = File.ReadAllText(AppContext.BaseDirectory + "SQL/SaveEntry.sql");
                string returnParameter = string.Empty;
                List<StorageProviderParameter> parameters = new List<StorageProviderParameter>
                {
                    new StorageProviderParameter { ParameterName = "@Name", ParameterValue = name, SqlDbType = SqlDbType.NVarChar },
                    new StorageProviderParameter { ParameterName = "@Phonenumber", ParameterValue = phonenumber, SqlDbType = SqlDbType.NVarChar }
                };
                DataSet dataSet = await _storageProvider.ExecuteQueryAsync(sqlQuery, parameters, new List<StorageProviderParameter>(), returnParameter, ConnectionType.READ, CommandType.Text);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Entry>> GetEntry(string name)
        {
            try
            {
                var sqlQuery = @"SELECT EntryID, 
                                [Name], 
                                Phonenumber
                                FROM[dbo].[Entry]
                                WHERE Name LIKE '%"+ name + "%'";
                string returnParameter = string.Empty;
                List<StorageProviderParameter> parameters = new List<StorageProviderParameter>();
                
                DataSet dataSet = await _storageProvider.ExecuteQueryAsync(sqlQuery, parameters, new List<StorageProviderParameter>(), returnParameter, ConnectionType.READ, CommandType.Text);

                List<Entry> entries = new List<Entry>();
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        var entry = new Entry
                        {
                            EntryID = Guid.Parse(row["EntryID"].ToString()),
                            Name = row["Name"].ToString(),
                            Phonenumber = row["Phonenumber"].ToString()
                        };
                        entries.Add(entry);
                    }
                    return entries;
                }
                return entries;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
