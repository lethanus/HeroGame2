using HeroesGame.Characters;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using HeroesGame.Mercenaries;

namespace HeroesGame.Repositories
{
    public class MercenaryJsonFileRepository : JsonListRepositoryForAccounts<Character>, IMercenaryRepository
    {
        public MercenaryJsonFileRepository(string directoryPath) : base(directoryPath, "Mercenaries") { }
    }
}
