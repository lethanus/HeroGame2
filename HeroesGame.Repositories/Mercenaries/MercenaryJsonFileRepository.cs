using HeroesGame.Characters;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using HeroesGame.Mercenaries;

namespace HeroesGame.Repositories
{
    public class MercenaryJsonFileRepository : IMercenaryRepository
    {
        private string _directoryPath;
        public MercenaryJsonFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void Add(Character mercenary, string accountID)
        {
            var _marcenaries = GetMercenariesForAccount(accountID);
            _marcenaries.Add(mercenary);
            SaveMercenariesForAccount(_marcenaries, accountID, _directoryPath);
        }

        public List<Character> GetAllMercenariesForUser(string accountID)
        {
            var _marcenaries = GetMercenariesForAccount(accountID);
            return _marcenaries;
        }

        private void SaveMercenariesForAccount(List<Character> characters, string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\Mercenaries_{accountID}.json";
            string json = JsonConvert.SerializeObject(characters, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        public List<Character> GetMercenariesForAccount(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\Mercenaries_{accountID}.json";
            if (!File.Exists(pathToFile))
            {
                return new List<Character>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<Character>>(json);
        }
    }


}
