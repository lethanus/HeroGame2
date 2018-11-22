using System.Collections.Generic;
using HeroesGame.Inventory;
using System.Linq;


namespace HeroesGame.Repositories
{
    public class PositionInInventoryJsonFileRepository : IPositionInInventoryRepository
    {

        private string _directoryPath;
        public PositionInInventoryJsonFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        private List<PositionInInventory> _positions = new List<PositionInInventory>();

        public void AddForAccount(PositionInInventory newItem, string accountID)
        {
            _positions.Add(newItem);
        }

        public List<PositionInInventory> GetAllForAcount(string accountID)
        {
            return _positions;
        }

        public void ChangeAmountForAccount(string itemID, int newAmount, string accountID)
        {
            _positions.First(x => x.ID == itemID).Amount = newAmount;
        }
    }
}
