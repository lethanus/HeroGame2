using System.Collections.Generic;
using HeroesGame.Inventory;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace HeroesGame.Repositories
{
    public class PositionInInventoryJsonFileRepository : AccountJsonListRepository<PositionInInventory>, IPositionInInventoryRepository
    {
        public PositionInInventoryJsonFileRepository(string directoryPath) : base(directoryPath, "Inventory") { }

        public void ChangeAmountForAccount(string itemID, int newAmount, string accountID)
        {
            var positions = GetAll(accountID);
            positions.First(x => x.ID == itemID).Amount = newAmount;
            SaveAll(positions, accountID, _directoryPath);
        }

    }
}
