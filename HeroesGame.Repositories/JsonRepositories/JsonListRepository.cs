using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HeroesGame.Common;

namespace HeroesGame.Repositories
{
    public class JsonListRepository<T>
    {
        private string _pathToRepoFile;

        public JsonListRepository(string pathToRepoFile)
        {
            _pathToRepoFile = pathToRepoFile;
        }

        public void Add(T template)
        {
            var items = GetAll();
            items.Add(template);
            SaveAll(items);
        }

        public List<T> GetAll()
        {
            if (!File.Exists(_pathToRepoFile))
            {
                return new List<T>();
            }
            var json = File.ReadAllText(_pathToRepoFile);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public void SaveAll(List<T> items)
        {
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(_pathToRepoFile, json);
        }
    }
}
