using System.Collections.Generic;


namespace HeroesGame.Inventory
{
    public interface IInventoryManagement
    {
        void AddItems(string itemID, int amount);
        List<PositionInInventory> GetAll();
        void RemoveItems(string itemID, int amount);
        List<PositionInInventory> GetAvailableGiftItems();
    }
}
