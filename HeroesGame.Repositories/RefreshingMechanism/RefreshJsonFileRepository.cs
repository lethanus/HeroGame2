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
            var refreshFacts = GetRefreshesForAccount(accountID, _directoryPath);
            var refreshFact = new RefreshFact { AccountID = accountID, Option = option, LastAction = actionTime };
            refreshFacts.Add(refreshFact);
            SaveRefreshesForAccount(refreshFacts, accountID, _directoryPath);
        }

        public List<RefreshFact> GetAllForUserAndOption(string accountID, string option)
        {
            return GetRefreshesForAccount(accountID, _directoryPath);
        }

        public string GetRefreshStatus(string option, string accountID, string refreshDelay, DateTime currentTime)
        {
            var refreshFacts = GetRefreshesForAccount(accountID, _directoryPath);
            int secondesToAdd = Int32.Parse(refreshDelay);
            var notPassedRefreshes = refreshFacts
                    .Where(x => x.Option == option && x.LastAction.AddSeconds(secondesToAdd) > currentTime);

            return notPassedRefreshes.Count() == 0 ? "Enabled" : "Disabled";
        }

        private void SaveRefreshesForAccount(List<RefreshFact> refreshes, string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\RefreshFacts_{accountID}.json";
            string json = JsonConvert.SerializeObject(refreshes, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        private List<RefreshFact> GetRefreshesForAccount(string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\RefreshFacts_{accountID}.json";
            if (!File.Exists(pathToFile))
            {
                return new List<RefreshFact>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<RefreshFact>>(json);
        }
    }
}
