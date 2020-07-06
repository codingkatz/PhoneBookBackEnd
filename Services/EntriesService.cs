using phonebookCollectionService.Models;
using phonebookCollectionService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace phonebookCollectionService.Services
{
    public class EntriesService : IEntriesService
    {
        private readonly IEntriesRepository _entriesRepository;
        public EntriesService(IEntriesRepository entriesRepository)
        {
            _entriesRepository = entriesRepository;
        }

        public async Task<List<Entry>> GetAllEntries()
        {
           return await _entriesRepository.GetAllEntries();
        }

        public async Task<List<Entry>> GetEntry(string name)
        {
            return await _entriesRepository.GetEntry(name);
        }

        public async Task<string> SaveEntry(string name, string phonenumber)
        {
            return await _entriesRepository.SaveEntry(name, phonenumber);
        }
    }
}
