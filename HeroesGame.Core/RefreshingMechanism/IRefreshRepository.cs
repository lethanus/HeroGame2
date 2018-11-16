using System;
using System.Collections.Generic;

namespace HeroesGame.RefresingMechanism
{
    public interface IRefreshRepository
    {
        void AddRefreshFact(string accountID, string option, DateTime actionTime);
        List<RefreshFact> GetRefreshesForAccount(string accountID);
    }
}
