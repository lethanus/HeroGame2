using System.Collections.Generic;
using HeroesGame.Mercenaries;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace HeroesGame.Repositories
{
    public class MercenaryTemplateJsonFileRepository : JsonListRepository<MercenaryTemplate>,  IMercenaryTemplateRepository
    {
        public MercenaryTemplateJsonFileRepository(string pathToRepoFile) : base(pathToRepoFile) { }
    }
}
