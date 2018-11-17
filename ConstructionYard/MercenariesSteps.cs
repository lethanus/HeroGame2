using System;
using TechTalk.SpecFlow;
using HeroesGame.Characters;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using System.Linq;
using BoDi;
using System.IO;
using System.Collections.Generic;
using HeroesGame.Accounts;

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
                mercenaryRepo.Add(mercenary);
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
            var mercenaryManagement = objectContainer.Resolve<IMercenaryManagement>();
            var accountMerceenaries = mercenaryManagement.GetAllMercenariesForLoggedUser();
            var expectedMercenaries = table.CreateSet<Character>();
            foreach (var mercenary in expectedMercenaries)
            {
                Assert.AreEqual(mercenary, accountMerceenaries.First(x => x.ID == mercenary.ID));
            }
        }

    }

    public interface IMercenaryRepository
    {
        void Add(Character mercenary);
        List<Character> GetAllMercenariesForUser(string accountID);
    }

    public class MercenaryMemoryRepository : IMercenaryRepository
    {
        private string _directory;
        private List<Character> _marcenaries;
        public MercenaryMemoryRepository(string directory)
        {
            _directory = directory;
            _marcenaries = new List<Character>();
        }

        public void Add(Character mercenary)
        {
            _marcenaries.Add(mercenary);
        }

        public List<Character> GetAllMercenariesForUser(string accountID)
        {
            return _marcenaries;
        }
    }

    public interface IMercenaryManagement
    {
        void AddNewMercenary(Character mercenary);
        List<Character> GetAllMercenariesForLoggedUser();
    }

    public class MercenaryManagement : IMercenaryManagement
    {
        private IMercenaryRepository _mercenaryRepository;
        private IAccountManagement _accountManagement;
        public MercenaryManagement(IMercenaryRepository mercenaryRepository, IAccountManagement accountManagement)
        {
            _mercenaryRepository = mercenaryRepository;
            _accountManagement = accountManagement;
        }

        public void AddNewMercenary(Character mercenary)
        {
            _mercenaryRepository.Add(mercenary);
        }

        public List<Character> GetAllMercenariesForLoggedUser()
        {
            return _mercenaryRepository.GetAllMercenariesForUser(_accountManagement.GetLoggedAccount().ID);
        }
    }


}
