using System;
using System.Linq;
using System.Collections.Generic;
using HeroesGame.RefresingMechanism;

namespace HeroesGame.Repositories
{
    public class MemoryRefreshRepository : IRefreshRepository
    {
        private Dictionary<string,List<RefreshFact>> refreshes = new Dictionary<string, List<RefreshFact>>();

        public void AddRefreshFact(string accountID, string option, DateTime actionTime)
        {
            var refreshFact = new RefreshFact { AccountID = accountID, Option = option, LastAction = actionTime };
            if (refreshes.ContainsKey(accountID))
            {
                refreshes[accountID].Add(refreshFact);
            }
            else refreshes.Add(accountID, new List<RefreshFact> { refreshFact });
        }

        public List<RefreshFact> GetAllForUserAndOption(string accountID, string option)
        {
            if (!refreshes.ContainsKey(accountID)) return new List<RefreshFact>();
            return refreshes[accountID].Where(x=>x.Option == option).ToList();
        }

        public string GetRefreshStatus(string option, string accountID, string refreshDelay, DateTime currentTime)
        {
            if (!refreshes.ContainsKey(accountID)) return "Enabled";
            else
            {
                int secondesToAdd = Int32.Parse(refreshDelay);
                var notPassedRefreshes = refreshes[accountID]
                    .Where(x => x.Option == option && x.LastAction.AddSeconds(secondesToAdd) > currentTime);
                if(notPassedRefreshes.Count() == 0 ) return "Enabled";
            }
            return "Disabled";
        }
    }
}
