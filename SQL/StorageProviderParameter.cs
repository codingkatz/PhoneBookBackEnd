using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.SQL
{
    public class StorageProviderParameter
    {
        public string ParameterName { get; set; }
        public object ParameterValue { get; set; }
        public SqlDbType SqlDbType { get; set; }
        public int? Size { get; set; }
        public byte? Precision { get; set; }
        public byte? Scale { get; set; }
    }
}
