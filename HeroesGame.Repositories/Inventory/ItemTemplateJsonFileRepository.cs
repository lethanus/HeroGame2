using System.Collections.Generic;
using HeroesGame.Inventory;
using Newtonsoft.Json;
using System.IO;

namespace HeroesGame.Repositories
{
    public class ItemTemplateJsonFileRepository : JsonListRepository<ItemTemplate>, IItemTemplateRepository
    {
        public ItemTemplateJsonFileRepository(string pathToRepoFile) : base(pathToRepoFile) { }
    }
}
