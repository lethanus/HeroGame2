using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            var items = GetAllFacts(accountID);
            item.FactOperation = FactOperation.ADD;
            item.FactTime = DateTime.Now;
            if (item.Amount == 0)
                item.Amount = 1;
            if (string.IsNullOrEmpty( item.Identyficator))
                item.Identyficator = item.ID;
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
            var facts = GetAllFacts(accountID);
            var items = new Dictionary<string, T>();
            foreach(var item in facts)
            {
                if(items.ContainsKey(item.Identyficator))
                {
                    if (item.FactOperation == FactOperation.ADD)
                        items[item.Identyficator].Amount += item.Amount;
                    else
                        items[item.Identyficator].Amount -= item.Amount;
                }
                else
                {
                    items.Add(item.Identyficator, item);
                }
            }

            return items.Values.Where(x=>x.Amount > 0).ToList();
        }

        protected List<T> GetAllFacts(string accountID)
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
            var allItems = GetAllFacts(accountID);
            var items = GetAll(accountID);
            foreach(var item in items)
            {
                item.FactOperation = FactOperation.REMOVE;
                item.FactTime = DateTime.Now;
                allItems.Add(item);
            }
            SaveAll(allItems, accountID, _directoryPath);
        }

        public void Remove(T item, string accountID)
        {
            var items = GetAllFacts(accountID);
            item.FactOperation = FactOperation.REMOVE;
            item.FactTime = DateTime.Now;
            items.Add(item);
            SaveAll(items, accountID, _directoryPath);
        }
    }
}
