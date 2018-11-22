using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using HeroesGame.Common;

namespace HeroesGame.Repositories
{
    public class JsonListRepositoryForAccounts<T> where T : ObjectWithID
    {
        protected readonly string _directoryPath;
        private readonly string _filePrefix;

        public JsonListRepositoryForAccounts(string directoryPath, string filePrefix)
        {
            _directoryPath = directoryPath;
            _filePrefix = filePrefix;
        }

        public void Add(T item, string accountID)
        {
            var items = GetAll(accountID);
            items.Add(item);
            SaveAll(items, accountID, _directoryPath);
        }

        public void SaveAll(List<T> items, string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\{_filePrefix}_{accountID}.json";
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        public List<T> GetAll(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\{_filePrefix}_{accountID}.json";
            if (!File.Exists(pathToFile))
            {
                return new List<T>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public void Clear(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\{_filePrefix}_{accountID}.json";
            List<T> items = new List<T>();
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        public void Remove(T item, string accountID)
        {
            var items = GetAll(accountID);
            var filtered = items.Where(x => x.ID != item.ID).ToList();
            SaveAll(filtered, accountID, _directoryPath);
        }
    }
}
