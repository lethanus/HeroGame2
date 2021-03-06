﻿using System.Collections.Generic;


namespace HeroesGame.Inventory
{
    public interface IPositionInInventoryRepository
    {
        void Add(PositionInInventory newItem, string accountID);
        List<PositionInInventory> GetAll (string accountID);
        void Remove(PositionInInventory position, string accountID);
    }
}
