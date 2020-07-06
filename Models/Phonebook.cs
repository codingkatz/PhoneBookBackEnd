using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.Models
{
    public class Phonebook
    {
        public Guid PhonebookID { get; set; }
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
