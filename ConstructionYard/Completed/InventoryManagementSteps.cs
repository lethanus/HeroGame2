using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Inventory;

namespace ConstructionYard
{
    [Binding]
    public class InventoryManagementSteps : HeroesGameTestsBase
    {
        public InventoryManagementSteps(IObjectContainer objectContainer) : base(objectContainer) { }

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
                itemTemplateRepository.Add(template);
            }
        }
        
        [When(@"Adding item with ID '(.*)' with amount '(.*)' to inventory")]
        public void WhenAddingItemWithIDWithAmountToInventory(string itemID, int amount)
        {
            var inventoryManagement = objectContainer.Resolve<IInventoryManagement>();
            inventoryManagement.AddItems(itemID, amount);
        }

        [When(@"Removing item with ID '(.*)' with amount '(.*)' to inventory")]
        public void WhenRemovingItemWithIDWithAmountToInventory(string itemID, int amount)
        {
            var inventoryManagement = objectContainer.Resolve<IInventoryManagement>();
            inventoryManagement.RemoveItems(itemID, amount);
        }


        [Then(@"Inventory should have items below")]
        public void ThenInventoryShouldHaveItemsBelow(Table table)
        {
            var inventoryManagement = objectContainer.Resolve<IInventoryManagement>();
            var positionsInInventory = inventoryManagement.GetAll();
            var expectedPositionsInInventory = table.CreateSet<PositionInInventory>().ToList();
            foreach (var item in expectedPositionsInInventory)
            {
                Assert.IsTrue(item.Equals(positionsInInventory.First(x => x.ID == item.ID)));
            }
            Assert.AreEqual(expectedPositionsInInventory.Count, positionsInInventory.Count);
        }
    }
}
