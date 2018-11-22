using System.Linq;
using System.Collections.Generic;
using HeroesGame.Accounts;


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
            var seletedItem = _itemTemplateRepository.GetAllTemplates().First(x=>x.ID == itemID);
            var allPositions = _positionInInventoryRepository.GetAllForAcount(_accountManagement.GetLoggedAccount().ID);
            var position = allPositions.FirstOrDefault(x => x.ID == itemID);
            if (position == null)
            {
                var newItem = new PositionInInventory
                { ID = seletedItem.ID, Category = seletedItem.Category, Name = seletedItem.Name, Amount = amount };
                _positionInInventoryRepository.AddForAccount(newItem, _accountManagement.GetLoggedAccount().ID);
            }
            else
            {
                _positionInInventoryRepository.ChangeAmountForAccount(position.ID, position.Amount + amount, _accountManagement.GetLoggedAccount().ID);
            }
        }

        public void AddPosition(PositionInInventory item)
        {
            _positionInInventoryRepository.AddForAccount(item, _accountManagement.GetLoggedAccount().ID);
        }

        public List<PositionInInventory> GetAll()
        {
            return _positionInInventoryRepository.GetAllForAcount(_accountManagement.GetLoggedAccount().ID);
        }
    }
}
