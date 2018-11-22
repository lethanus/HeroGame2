using System;
using System.Linq;
using System.Collections.Generic;
using HeroesGame.RefresingMechanism;
using Newtonsoft.Json;
using System.IO;

namespace HeroesGame.Repositories
{
    public class RefreshJsonFileRepository : AccountJsonListRepository<RefreshFact>,  IRefreshRepository
    {
        public RefreshJsonFileRepository(string directoryPath) : base(directoryPath, "RefreshFacts") { }
    }
}
