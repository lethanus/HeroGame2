using System;
using TechTalk.SpecFlow;
using HeroesGame.Characters;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using BoDi;
using HeroesGame.Mercenaries;
using HeroesGame.Configuration;
using HeroesGame.Core.Randomizers;
using HeroesGame.Accounts;
using HeroesGame.Inventory;

namespace ConstructionYard
{
    [Binding]
    public class MercenariesSteps
    {
        private readonly IObjectContainer objectContainer;
        private Mercenary _newMercenary;
        
        private DateTime _currentTime = DateTime.Now;

        public MercenariesSteps(IObjectContainer objectContainer)
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

        [Given(@"Account '(.*)' already have some mercenaries")]
        public void GivenAccountAlreadyHaveSomeMercenaries(string accountID, Table table)
        {
            var mercenaryRepo = objectContainer.Resolve<IMercenaryRepository>();
            var expectedMercenaries = table.CreateSet<Character>();
            foreach (var mercenary in expectedMercenaries)
            {
                mercenaryRepo.Add(mercenary, accountID);
            }
        }

        [When(@"Player will add new mercenary")]
        public void WhenPlayerWillAddNewMercenary(Table table)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            var expectedMercenaries = table.CreateSet<Character>();
            foreach (var mercenary in expectedMercenaries)
            {
                mercenaryManagement.AddNewMercenary(mercenary);
            }
        }

        [Then(@"Account '(.*)' should have mercenaries")]
        public void ThenAccountAlreadyHaveSomeMercenaries(string accountID, Table table)
        {
            var mercenaryRepository = objectContainer.Resolve<IMercenaryRepository>();
            var accountMerceenaries = mercenaryRepository.GetAll(accountID);
            var expectedMercenaries = table.CreateSet<Character>();
            foreach (var mercenary in expectedMercenaries)
            {
                Assert.AreEqual(mercenary, accountMerceenaries.First(x => x.ID == mercenary.ID));
            }
        }

        [Then(@"Logged account should have mercenaries")]
        public void ThenLoggedAccountShouldHaveMercenaries(Table table)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            var accountMerceenaries = mercenaryManagement.GetAllMercenariesForLoggedUser();
            var expectedMercenaries = table.CreateSet<Character>();
            foreach (var mercenary in expectedMercenaries)
            {
                Assert.AreEqual(mercenary, accountMerceenaries.First(x => x.ID == mercenary.ID));
            }
        }

        [Given(@"Some mercenary templates")]
        public void GivenSomeMercenaryTemplates(Table table)
        {
            var mercenaryTemplateRepo = objectContainer.Resolve<IMercenaryTemplateRepository>();
            var mercenaries = table.CreateSet<MercenaryTemplate>().ToList();
            foreach (var mercenary in mercenaries)
            {
                mercenaryTemplateRepo.Add(mercenary);
            }
            Assert.Greater(mercenaryTemplateRepo.GetAll().Count, 0);
        }

        [When(@"Creating mercenary '(.*)' of level '(.*)'")]
        public void WhenCreatingMercenaryOfLevel(string mercenaryName, int mercenaryLevel)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            _newMercenary = mercenaryManagement.GetMercenaryBaseOnTemplate(mercenaryName, mercenaryLevel);
        }

        [Then(@"Created mercenary should have '(.*)' between '(.*)' and '(.*)'")]
        public void ThenCreatedMercanaryShouldHaveBetweenAnd(string stat, int minValue, int maxValue)
        {
            var valueToCompare = 0;
            switch(stat)
            {
                case "Hp": { valueToCompare = _newMercenary.Hp; break; }
                case "Attack_Min": { valueToCompare = _newMercenary.Attack_Min; break; }
                case "Attack_Max": { valueToCompare = _newMercenary.Attack_Max; break; }
                case "Defence": { valueToCompare = _newMercenary.Defence; break; }
                case "Speed": { valueToCompare = _newMercenary.Speed; break; }
            }
            Assert.GreaterOrEqual(valueToCompare, minValue);
            Assert.GreaterOrEqual(maxValue, valueToCompare);
        }

        [Given(@"Number of recruits is set to '(.*)'")]
        public void GivenNumberOfRecruitsIsSetTo(int numberOfRecruits)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"NumberOfRecruits", numberOfRecruits.ToString());
        }

        [When(@"User will use refresh for mercenaries")]
        public void WhenUserWithIDWillUseRefreshForMercenaries()
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            mercenaryManagement.GenerateMercenaries();
        }


        [Then(@"Count of potential recruits generated should be '(.*)' for user with ID '(.*)'")]
        public void ThenCountOfPotentialRecruitsGeneratedShouldBe(int expectedCount, string accoutID)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            Assert.AreEqual(expectedCount, mercenaryManagement.GetRecruits().Count());
        }

        [Given(@"The chance of getting level '(.*)' mercenaries is set to '(.*)' of '(.*)'")]
        public void GivenTheChanceOfGettingLevelMercenariesIsSetToOf(int level, int chanceValue, int chanceMax)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"ChanceForLevel_{level}_mercenary", $"{chanceValue}_{chanceMax}");
        }

        [Given(@"Randomzer for mercenary level will always return '(.*)'")]
        public void GivenRandomzerForMercenaryLevelWillAlwaysReturn(int randomizerResult)
        {
            var randomizer = objectContainer.Resolve<IValueRandomizer>();
            randomizer.SetReturnValue($"Mercenary_level_chance", randomizerResult);
        }


        [Then(@"All potential recruits should have set '(.*)' to '(.*)'")]
        public void ThenAllPotentialRecruitsShouldHaveSetTo(string stat, string value)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            foreach (var mercenary in mercenaryManagement.GetRecruits())
            {
                var valueToCompare = "";
                switch (stat)
                {
                    case "Name": { valueToCompare = mercenary.Name; break; }
                    case "Level": { valueToCompare = mercenary.Level.ToString(); break; }
                }
                Assert.AreEqual(value, valueToCompare);
            }
        }

        [Then(@"All potential recruits should have set value of '(.*)' between '(.*)' and '(.*)'")]
        public void ThenAllPotentialRecruitsShouldHaveSetBetweenAnd(string stat, int minValue, int maxValue)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            foreach (var mercenary in mercenaryManagement.GetRecruits())
            {
                var valueToCompare = 0;
                switch (stat)
                {
                    case "Hp": { valueToCompare = mercenary.Hp; break; }
                    case "Attack_Min": { valueToCompare = mercenary.Attack_Min; break; }
                    case "Attack_Max": { valueToCompare = mercenary.Attack_Max; break; }
                    case "Defence": { valueToCompare = mercenary.Defence; break; }
                    case "Speed": { valueToCompare = mercenary.Speed; break; }
                }
                Assert.GreaterOrEqual(valueToCompare, minValue);
                Assert.GreaterOrEqual(maxValue, valueToCompare);
            }
        }

        [Then(@"There are some potential recruits with '(.*)' equal to '(.*)'")]
        public void ThenThereAreSomePotentialRecruitsWithEqualTo(string stat, string value)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            if (stat == "Name")
            {
                var count = mercenaryManagement.GetRecruits().Count(x => x.Name == value);
                Assert.Greater(count, 0);
            }
            else Assert.AreEqual(0, 1);
        }

        [Given(@"There as some recruits")]
        public void GivenThereAsSomeRecruits(Table table)
        {
            var recruitRepo = objectContainer.Resolve<IRecruitsRepository>();
            var accountManagement = objectContainer.Resolve<IAccountManagement>();
            
            var recruits = table.CreateSet<Mercenary>().ToList();
            foreach (var recruit in recruits)
            {
                recruitRepo.Add(recruit, accountManagement.GetLoggedAccount().ID);
            }
            Assert.AreEqual(table.RowCount, recruitRepo.GetAll(accountManagement.GetLoggedAccount().ID).Count);
        }

        [Given(@"The chance of convincing level '(.*)' recruits is set to '(.*)' of '(.*)'")]
        public void GivenTheChanceOfConvincingLevelRecruitsIsSetToOf(int level, int chanceValue, int chanceMax)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"ConvinceLevel_{level}_recruit", $"{chanceValue}_{chanceMax}");
        }

        [Given(@"Randomzer for convincing recruits will always return '(.*)'")]
        public void GivenRandomzerForConvincingRecruitsWillAlwaysReturn(int randomizerResult)
        {
            var randomizer = objectContainer.Resolve<IValueRandomizer>();
            randomizer.SetReturnValue($"Recruits_convincing", randomizerResult);
        }

        [When(@"Logged user will try to convince recruit with ID '(.*)'")]
        public void WhenLoggedUserWillTryToConvinceRecruitWithID(string recruitID)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            var recruit = mercenaryManagement.GetRecruits().First(x => x.ID == recruitID);
            mercenaryManagement.ConvinceRecruit(recruit);
        }

        [Given(@"Valid as a gifts are items")]
        public void GivenValidAsAGiftsAreItems(Table table)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            var itemsAsGifts = mercenaryManagement.GetAvailableGiftItems();
            var expectedGiftItems = table.CreateSet<PositionInInventory>().ToList();
            foreach (var item in expectedGiftItems)
            {
                Assert.AreEqual(1, itemsAsGifts.Count(x => x.ID == item.ID));
            }
            Assert.AreEqual(expectedGiftItems.Count, itemsAsGifts.Count);
        }

        [When(@"Valid as a gifts are items")]
        public void WhenValidAsAGiftsAreItems(Table table)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            var itemsAsGifts = mercenaryManagement.GetAvailableGiftItems();
            var expectedGiftItems = table.CreateSet<PositionInInventory>().ToList();
            foreach (var item in expectedGiftItems)
            {
                Assert.AreEqual(1, itemsAsGifts.Count(x => x.ID == item.ID));
            }
            Assert.AreEqual(expectedGiftItems.Count, itemsAsGifts.Count);
        }


        [When(@"Looged user will add '(.*)' items with ID '(.*)' as a gift")]
        public void WhenLoogedUserWillAddItemsWithIDAsAGift(int amount, string itemID)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            mercenaryManagement.AddGifts(itemID, amount);
        }

        [When(@"List of gifts should have items below")]
        public void WhenListOfGiftsShouldHaveItemsBelow(Table table)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            var currentGifts = mercenaryManagement.GetCurrentGifts();
            var expectedGiftItems = table.CreateSet<PositionInInventory>().ToList();
            foreach (var item in expectedGiftItems)
            {
                Assert.AreEqual(item, currentGifts.First(x => x.ID == item.ID));
            }
            Assert.AreEqual(expectedGiftItems.Count, currentGifts.Count);
        }

        [When(@"Looged user will remove '(.*)' items with ID '(.*)' from gifts")]
        public void WhenLoogedUserWillRemoveItemsWithIDFromGifts(int amount, string itemID)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            mercenaryManagement.RemoveGifts(itemID, amount);
        }

    }

}
