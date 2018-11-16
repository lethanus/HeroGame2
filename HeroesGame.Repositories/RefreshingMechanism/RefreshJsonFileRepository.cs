using System;
using System.Linq;
using System.Collections.Generic;
using HeroesGame.RefresingMechanism;
using Newtonsoft.Json;
using System.IO;

namespace HeroesGame.Repositories
{
    public class RefreshJsonFileRepository : IRefreshRepository
    {
        private string _directoryPath = "";
        public RefreshJsonFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void AddRefreshFact(string accountID, string option, DateTime actionTime)
        {
            var refreshFacts = GetRefreshesForAccount(accountID);
            var refreshFact = new RefreshFact { AccountID = accountID, Option = option, LastAction = actionTime };
            refreshFacts.Add(refreshFact);
            SaveRefreshesForAccount(refreshFacts, accountID, _directoryPath);
        }

        private void SaveRefreshesForAccount(List<RefreshFact> refreshes, string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\RefreshFacts_{accountID}.json";
            string json = JsonConvert.SerializeObject(refreshes, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        public List<RefreshFact> GetRefreshesForAccount(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\RefreshFacts_{accountID}.json";
            if (!File.Exists(pathToFile))
            {
                return new List<RefreshFact>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<RefreshFact>>(json);
        }
    }
}
