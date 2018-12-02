using System.Linq;
using System.Collections.Generic;
using HeroesGame.Accounts;
using System;

namespace HeroesGame.Inventory
{
    public class InventoryManagement : IInventoryManagement
    {
        private IItemTemplateRepository _itemTemplateRepository;
        private readonly IPositionInInventoryRepository _positionInInventoryRepository;
        private readonly IAccountManagement _accountManagement;
        public InventoryManagement(IItemTemplateRepository itemTemplateRepository, IPositionInInventoryRepository positionInInventoryRepository, IAccountManagement accountManagement)
        {
            _itemTemplateRepository = itemTemplateRepository;
            _positionInInventoryRepository = positionInInventoryRepository;
            _accountManagement = accountManagement;
        }


        public void AddItems(string itemID, int amount)
        {
            var seletedItem = _itemTemplateRepository.GetAll().First(x => x.ID == itemID);

            var newItem = new PositionInInventory
            { ID = $"{Guid.NewGuid().ToString()}_{seletedItem.ID}", Identyficator = seletedItem.Name,  Category = seletedItem.Category, Name = seletedItem.Name, Amount = amount, Effects = seletedItem.Effects };
            _positionInInventoryRepository.Add(newItem, _accountManagement.GetLoggedAccount().ID);

        }

        public List<PositionInInventory> GetAll()
        {
            return _positionInInventoryRepository.GetAll(_accountManagement.GetLoggedAccount().ID);
        }

        public void RemoveItems(string identyficator, int amount)
        {
            var allPositions = _positionInInventoryRepository.GetAll(_accountManagement.GetLoggedAccount().ID);
            var position = allPositions.First(x => x.Identyficator == identyficator);
            if (position.Amount >= amount)
            {
                position.Amount = amount;
                var removedItem = new PositionInInventory
                { ID = position.ID, Identyficator = position.Name, Category = position.Category, Name = position.Name, Amount = position.Amount, Effects = position.Effects };

                _positionInInventoryRepository.Remove(removedItem, _accountManagement.GetLoggedAccount().ID);
            }
        }

        public List<PositionInInventory> GetAvailableGiftItems()
        {
            return _positionInInventoryRepository.GetAll(_accountManagement.GetLoggedAccount().ID)
                .Where(x => x.Category == ItemCategory.Trophy).ToList();
        }
    }
}
