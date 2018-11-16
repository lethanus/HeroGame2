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

namespace ConstructionYard
{
    [Binding]
    public class RefreshingMechanismSteps
    {
        private readonly IObjectContainer objectContainer;
        private DateTime _currentTime = DateTime.Now;
        

        public RefreshingMechanismSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeAccountRepository()
        {
            var accountRepo = new AccountJsonFileRepository("accounts.json");
            objectContainer.RegisterInstanceAs<IAccountRepository>(accountRepo);
            var refreshRepo = new MemoryRefreshRepository();
            objectContainer.RegisterInstanceAs<IRefreshRepository>(refreshRepo);
            var configRepo = new MemoryConfigRepository();
            objectContainer.RegisterInstanceAs<IConfigRepository>(configRepo);
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
            var refreshRepo = objectContainer.Resolve<IRefreshRepository>();
            var refreshFacts = table.CreateSet<RefreshFact>().ToList();
            foreach (var refresh in refreshFacts)
            {
                refreshRepo.AddRefreshFact(refresh.AccountID, refresh.Option, refresh.LastAction);
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
            var refreshRepo = objectContainer.Resolve<IRefreshRepository>();
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            var parameterName = $"Delay_for_option_{option}_in_sec";

            var actualStatus = refreshRepo.GetRefreshStatus(option, accountID, configRepo.GetParameterValue(parameterName), _currentTime);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        
        [When(@"player with account ID '(.*)' will use refresh for '(.*)' option at '(.*)'")]
        public void WhenPlayerWillUseRefreshForOptionAt(string accountID, string option, DateTime actionTime)
        {
            var refreshRepo = objectContainer.Resolve<IRefreshRepository>();
            refreshRepo.AddRefreshFact(accountID, option, actionTime);
        }
        
        [Then(@"Refresh for option '(.*)' is '(.*)' for account ID '(.*)'")]
        public void ThenRefreshForOptionIsAndNextRefreshIsAvailableAt(string option, string expectedStatus, string accountID)
        {
            var refreshRepo = objectContainer.Resolve<IRefreshRepository>();
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            var parameterName = $"Delay_for_option_{option}_in_sec";

            var actualStatus = refreshRepo.GetRefreshStatus(option, accountID, configRepo.GetParameterValue(parameterName), _currentTime);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
