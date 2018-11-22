using System.Collections.Generic;


namespace HeroesGame.Inventory
{
    public interface IInventoryManagement
    {
        void AddItems(string itemID, int amount);
        void AddPosition(PositionInInventory item);
        List<PositionInInventory> GetAll();
    }
}
