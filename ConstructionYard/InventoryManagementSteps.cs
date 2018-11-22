using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Accounts;


namespace ConstructionYard
{
    [Binding]
    public class InventoryManagementSteps
    {
        private readonly IObjectContainer objectContainer;

        public InventoryManagementSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeRepository()
        {
            TestInstaler.InitializeRepository(objectContainer);
        }

        [AfterScenario]
        public void CleanupRepository()
        {
            TestInstaler.CleanupRepository();
        }

        [Given(@"Inventory already contains items below")]
        public void GivenInventoryAlreadyContainsItemsBelow(Table table)
        {
            var inventoryManagement = objectContainer.Resolve<IInventoryManagement>();
            var positionsInInventory = table.CreateSet<PositionInInventory>().ToList();
            foreach(var item in positionsInInventory)
            {
                inventoryManagement.AddPosition(item);
            }
        }
        
        [Given(@"Items dictionary contains items below")]
        public void GivenItemsDictionaryContainsItemsBelow(Table table)
        {
            var itemTemplateRepository = objectContainer.Resolve<IItemTemplateRepository>();
            var itemTemplates = table.CreateSet<ItemTemplate>().ToList();
            foreach (var template in itemTemplates)
            {
                itemTemplateRepository.AddTemplate(template);
            }
        }
        
        [When(@"Adding item with ID '(.*)' with amount '(.*)' to inventory")]
        public void WhenAddingItemWithIDWithAmountToInventory(string itemID, int amount)
        {
            var inventoryManagement = objectContainer.Resolve<IInventoryManagement>();
            inventoryManagement.AddItems(itemID, amount);
        }
        
        [Then(@"Inventory should have items below")]
        public void ThenInventoryShouldHaveItemsBelow(Table table)
        {
            var inventoryManagement = objectContainer.Resolve<IInventoryManagement>();
            var positionsInInventory = inventoryManagement.GetAll();
            var expectedPositionsInInventory = table.CreateSet<PositionInInventory>().ToList();
            foreach (var item in expectedPositionsInInventory)
            {
                Assert.AreEqual(item, positionsInInventory.First(x => x.ID == item.ID));
            }
        }
    }

    public class ItemTemplate
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class PositionInInventory
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }

        public override bool Equals(object obj)
        {
            var toCompare = obj as PositionInInventory;
            var result =
                ID == toCompare.ID &&
                Name == toCompare.Name &&
                Category == toCompare.Category &&
                Amount == toCompare.Amount;
            return result;
        }
    }

    public interface IItemTemplateRepository
    {
        void AddTemplate(ItemTemplate template);
        List<ItemTemplate> GetAllTemplates();
    }

    public class ItemTemplateJsonFileRepository : IItemTemplateRepository
    {
        private List<ItemTemplate> _itemTemplates = new List<ItemTemplate>();
        private string _pathToRepoFile;

        public ItemTemplateJsonFileRepository(string pathToRepoFile)
        {
            _pathToRepoFile = pathToRepoFile;
        }

        public void AddTemplate(ItemTemplate template)
        {
            _itemTemplates.Add(template);
        }

        public List<ItemTemplate> GetAllTemplates()
        {
            return _itemTemplates;
        }
    }

    public interface IPositionInInventoryRepository
    {
        void AddForAccount(PositionInInventory newItem, string accountID);
        List<PositionInInventory> GetAllForAcount(string accountID);
    }

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
    }

    public interface IInventoryManagement
    {
        void AddItems(string itemID, int amount);
        void AddPosition(PositionInInventory item);
        List<PositionInInventory> GetAll();
    }

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
            var newItem = new PositionInInventory
                { ID = seletedItem.ID, Category = seletedItem.Category, Name = seletedItem.Name, Amount = amount };

            _positionInInventoryRepository.AddForAccount(newItem, _accountManagement.GetLoggedAccount().ID);
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
