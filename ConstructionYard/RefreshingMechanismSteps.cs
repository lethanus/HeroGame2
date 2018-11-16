using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using HeroesGame.Configuration;
using HeroesGame.RefresingMechanism;
using HeroesGame.Accounts;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Repositories;
using System.IO;

namespace ConstructionYard
{
    [Binding]
    public class RefreshingMechanismSteps
    {
        private readonly IObjectContainer objectContainer;
        private DateTime _currentTime = DateTime.Now;
        private RefreshingMechnism _refreshingMechnism;

        public RefreshingMechanismSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeRepository()
        {
            var accountRepo = new AccountJsonFileRepository("accountsForRefresh.json");
            objectContainer.RegisterInstanceAs<IAccountRepository>(accountRepo);
            var refreshRepo = new RefreshJsonFileRepository(Directory.GetCurrentDirectory());
            objectContainer.RegisterInstanceAs<IRefreshRepository>(refreshRepo);
            var configRepo = new ConfigJsonFileRepository("configuration.json");
            objectContainer.RegisterInstanceAs<IConfigRepository>(configRepo);
            _refreshingMechnism = new RefreshingMechnism(refreshRepo, configRepo);
        }

        [AfterScenario]
        public void CleanupRepository()
        {
            File.Delete("accountsForRefresh.json");
            File.Delete("configuration.json");
            foreach(var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                if(file.Contains("RefreshFacts_"))
                    File.Delete(file);
            }
        }

        [Given(@"that there was no refresh actions before for option '(.*)' for account ID '(.*)'")]
        public void GivenThatThereWasNoRefreshActionsBeforeForOption(string option, string accountID)
        {
            var refreshRepo = objectContainer.Resolve<IRefreshRepository>();
            var refreshes = refreshRepo.GetAllForUserAndOption(accountID, option);
            Assert.AreEqual(0, refreshes.Count);
        }

        [Given(@"that there are some refresh actions")]
        public void GivenThatThereWasAreSomeRefreshActionsBeforeForOptionForAccountID(Table table)
        {
            var refreshFacts = table.CreateSet<RefreshFact>().ToList();
            foreach (var refresh in refreshFacts)
            {
                _refreshingMechnism.AddRefreshFact(refresh.Option, refresh.AccountID, refresh.LastAction);
            }
        }


        [Given(@"current time is set to '(.*)'")]
        public void GivenCurrentTimeIsSetTo(DateTime currentTime)
        {
            _currentTime = currentTime;
        }
        
        [Given(@"Refresh time for option '(.*)' is set to '(.*)' seconds")]
        public void GivenRefreshTimeForOptionIsSetToSeconds(string option, string delayInSeconds)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"Delay_for_option_{option}_in_sec", delayInSeconds);
        }
        
        [When(@"mechanizm will set refresh to '(.*)' for option '(.*)' for account ID '(.*)'")]
        public void WhenMechanizmWillSetRefreshToForOption(string expectedStatus, string option, string accountID)
        {
            var actualStatus = _refreshingMechnism.GetRefreshStatus(option, accountID, _currentTime);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        
        [When(@"player with account ID '(.*)' will use refresh for '(.*)' option at '(.*)'")]
        public void WhenPlayerWillUseRefreshForOptionAt(string accountID, string option, DateTime actionTime)
        {
            _refreshingMechnism.AddRefreshFact(option, accountID, actionTime);
        }
        
        [Then(@"Refresh for option '(.*)' is '(.*)' for account ID '(.*)'")]
        public void ThenRefreshForOptionIsAndNextRefreshIsAvailableAt(string option, string expectedStatus, string accountID)
        {
            var actualStatus = _refreshingMechnism.GetRefreshStatus(option, accountID, _currentTime);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
