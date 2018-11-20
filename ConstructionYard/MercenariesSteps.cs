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

namespace ConstructionYard
{
    [Binding]
    public class MercenariesSteps
    {
        private readonly IObjectContainer objectContainer;
        private Mercenary _newMercenary;
        private List<Mercenary> _generatedMercenaries;
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
            var accountMerceenaries = mercenaryRepository.GetAllMercenariesForUser(accountID);
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
                mercenaryTemplateRepo.AddMercenaryTemplate(mercenary);
            }
            Assert.Greater(mercenaryTemplateRepo.GetMercenaryTemplates().Count, 0);
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
                case "Attack": { valueToCompare = _newMercenary.Attack; break; }
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

        [When(@"User with ID '(.*)' will use refresh for mercenaries")]
        public void WhenUserWithIDWillUseRefreshForMercenaries(string accountID)
        {
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            _generatedMercenaries = mercenaryManagement.GenerateMercenaries(accountID);
        }


        [Then(@"Count of potential recruits generated should be '(.*)' for user with ID '(.*)'")]
        public void ThenCountOfPotentialRecruitsGeneratedShouldBe(int expectedCount, string accoutID)
        {
            Assert.AreEqual(expectedCount, _generatedMercenaries.Count());
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
            foreach(var mercenary in _generatedMercenaries)
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
            foreach (var mercenary in _generatedMercenaries)
            {
                var valueToCompare = 0;
                switch (stat)
                {
                    case "Hp": { valueToCompare = mercenary.Hp; break; }
                    case "Attack": { valueToCompare = mercenary.Attack; break; }
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
            if(stat == "Name")
            {
                var count = _generatedMercenaries.Count(x => x.Name == value);
                Assert.Greater(count, 0);
            }
            else Assert.AreEqual(0, 1);
        }


    }


}
