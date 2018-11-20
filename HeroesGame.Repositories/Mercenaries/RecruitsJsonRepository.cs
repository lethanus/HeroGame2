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
    public class RecruitsJsonRepository : IRecruitsRepository
    {

        private string _directoryPath;
        public RecruitsJsonRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void Add(Mercenary recruit, string accountID)
        {
            var recruits = GetRecruitsForAccount(accountID);
            recruits.Add(recruit);
            SaveRecruitsForAccount(recruits, accountID, _directoryPath);
        }

        public List<Mercenary> GetAllRecruitsForUser(string accountID)
        {
            var recruits = GetRecruitsForAccount(accountID);
            return recruits;
        }

        private void SaveRecruitsForAccount(List<Mercenary> recruits, string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\Recruits_{accountID}.json";
            string json = JsonConvert.SerializeObject(recruits, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }


        public List<Mercenary> GetRecruitsForAccount(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\Recruits_{accountID}.json";
            if (!File.Exists(pathToFile))
            {
                return new List<Mercenary>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<Mercenary>>(json);
        }

    }
}
