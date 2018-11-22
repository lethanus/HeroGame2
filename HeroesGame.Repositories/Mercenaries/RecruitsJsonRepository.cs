using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Mercenaries;
using System.IO;
using Newtonsoft.Json;

namespace HeroesGame.Repositories
{
    public class RecruitsJsonRepository : AccountJsonListRepository<Mercenary>, IRecruitsRepository
    {
        public RecruitsJsonRepository(string directoryPath) : base(directoryPath, "Recruits") { }

        public void Clear(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\Recruits_{accountID}.json";
            List<Mercenary> recruits = new List<Mercenary>();
            string json = JsonConvert.SerializeObject(recruits, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        public void Remove(Mercenary recruit, string accountID)
        {
            var recruits = GetAll(accountID);
            var filtered = recruits.Where(x => x.ID != recruit.ID).ToList();
            SaveAll(filtered, accountID, _directoryPath);
        }
    }
}
