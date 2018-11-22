using System;
using System.Linq;
using System.Collections.Generic;
using HeroesGame.RefresingMechanism;
using Newtonsoft.Json;
using System.IO;

namespace HeroesGame.Repositories
{
    public class RefreshJsonFileRepository : JsonListRepositoryForAccounts<RefreshFact>,  IRefreshRepository
    {
        public RefreshJsonFileRepository(string directoryPath) : base(directoryPath, "RefreshFacts") { }
    }
}
