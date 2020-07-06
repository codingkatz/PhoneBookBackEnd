using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.Models
{
    public class Entry
    {
        public Guid EntryID { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
    }
}
