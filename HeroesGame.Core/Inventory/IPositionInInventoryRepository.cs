using System.Collections.Generic;


namespace HeroesGame.Inventory
{
    public interface IPositionInInventoryRepository
    {
        void AddForAccount(PositionInInventory newItem, string accountID);
        List<PositionInInventory> GetAllForAcount(string accountID);
        void ChangeAmountForAccount(string itemID, int amount, string accountID);
    }
}
