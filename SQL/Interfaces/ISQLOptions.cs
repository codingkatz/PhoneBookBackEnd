using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.SQL.Interfaces
{
    public interface ISQLOptions
    {
        string WriteConnectionString { get; set; }
        string ReadConnectionString { get; set; }
        int WriteCommandTimeout { get; set; }
        int ReadCommandTimeout { get; set; }
    }
}
