using phonebookCollectionService.SQL.Interfaces;

namespace phonebookCollectionService.SQL
{
    public class SQLOptions : ISQLOptions
    {
        public string WriteConnectionString { get; set; }
        public string ReadConnectionString { get; set; }
        public int WriteCommandTimeout { get; set; }
        public int ReadCommandTimeout { get; set; }
    }
}
