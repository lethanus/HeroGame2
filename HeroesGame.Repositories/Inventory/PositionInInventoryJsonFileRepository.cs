using System.Collections.Generic;
using HeroesGame.Inventory;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using HeroesGame.Common;

namespace HeroesGame.Repositories
{
    public class PositionInInventoryJsonFileRepository : JsonListRepositoryForAccounts<PositionInInventory>, IPositionInInventoryRepository
    {
        public PositionInInventoryJsonFileRepository(string directoryPath) : base(directoryPath, "Inventory") { }
    }
}
