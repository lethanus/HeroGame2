using System;
using TechTalk.SpecFlow;
using HeroesGame.Characters;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using BoDi;
using HeroesGame.Mercenaries;

namespace ConstructionYard
{
    [Binding]
    public class MercenariesSteps
    {
        private readonly IObjectContainer objectContainer;
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
            
        }

        [Then(@"Created mercenary should have '(.*)' between '(.*)' and '(.*)'")]
        public void ThenCreatedMercanaryShouldHaveBetweenAnd(string stat, int minValue, int maxValue)
        {
            Assert.AreEqual(true, false);
        }


    }
    public interface IMercenaryTemplateRepository
    {
        void AddMercenaryTemplate(MercenaryTemplate mercenary);
        List<MercenaryTemplate> GetMercenaryTemplates();
    }

    public class MercenaryTemplateRepository : IMercenaryTemplateRepository
    {
        private List<MercenaryTemplate> _mercenaryTemplates = new List<MercenaryTemplate>();
        public void AddMercenaryTemplate(MercenaryTemplate mercenary)
        {
            _mercenaryTemplates.Add(mercenary);
        }

        public List<MercenaryTemplate> GetMercenaryTemplates()
        {
            return _mercenaryTemplates;
        }
    }


    public class MercenaryTemplate
    {
        public string Level { get; set; }
        public string Name { get; set; }
        public string HP_range { get; set; }
        public string Attack_range { get; set; }
        public string Defence_range { get; set; }
        public string Speed_range { get; set; }

    }


}
