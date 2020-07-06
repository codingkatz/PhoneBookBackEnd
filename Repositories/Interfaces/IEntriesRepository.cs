using phonebookCollectionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebookCollectionService.Repositories.Interfaces
{
    public interface IEntriesRepository
    {
        Task<List<Entry>> GetAllEntries();
        Task<string> SaveEntry(string name, string phonenumber);
        Task<List<Entry>> GetEntry(string name);
    }
}
