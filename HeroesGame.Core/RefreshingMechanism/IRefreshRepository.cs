using System;
using System.Collections.Generic;

namespace HeroesGame.RefresingMechanism
{
    public interface IRefreshRepository
    {
        void Add(RefreshFact refresh, string accountID);
        List<RefreshFact> GetAll(string accountID);
    }
}
