using System;
using System.Collections.Generic;

namespace HeroesGame.RefresingMechanism
{
    public interface IRefreshRepository
    {
        void AddRefreshFact(string accountID, string option, DateTime actionTime);
        List<RefreshFact> GetAllForUserAndOption(string accountID, string option);
        string GetRefreshStatus(string option, string accountID, string refreshDelay, DateTime currentTime);
    }
}
