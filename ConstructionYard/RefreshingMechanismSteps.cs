using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using HeroGame.Accounts;
using NUnit.Framework;
using System.Collections.Generic;

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
            var actualStatus = "empty";

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        
        [When(@"player with account ID '(.*)' will use refresh for '(.*)' option at '(.*)'")]
        public void WhenPlayerWillUseRefreshForOptionAt(string accountID, string option, DateTime actionTime)
        {
            
        }
        
        [Then(@"Refresh for option '(.*)' is '(.*)' and next refresh is available at '(.*)' for account ID '(.*)'")]
        public void ThenRefreshForOptionIsAndNextRefreshIsAvailableAt(string option, string expectedStatus, DateTime nextActionTime, string accountID)
        {
            var actualStatus = "empty";

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }

    public interface IRefreshRepository
    {
        List<RefreshFact> GetAllForUserAndOption(string accountID, string option);
    }

    public class MemoryRefreshRepository : IRefreshRepository
    {
        private List<RefreshFact> refreshes = new List<RefreshFact>();
        public List<RefreshFact> GetAllForUserAndOption(string accountID, string option)
        {
            return refreshes.Where(x=>x.Option == option).ToList();
        }
    }

    public class RefreshFact
    {
        public string AccountID { get; set; }
        public string Option { get; set; }
        public DateTime LastAction { get; set; }

    }

    public interface IConfigRepository
    {
        void SetConfigParameter(string parameter, string value);

    }

    public class MemoryConfigRepository : IConfigRepository
    {
        private Dictionary<string, string> _configValues = new Dictionary<string, string>();
        public void SetConfigParameter(string parameter, string value)
        {
            _configValues.Add(parameter, value);
        }
    }
}
