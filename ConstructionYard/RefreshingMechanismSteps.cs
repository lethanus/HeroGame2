﻿using System;
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
        
        [Then(@"Refresh for option '(.*)' is '(.*)' and next refresh is available at '(.*)' for account ID '(.*)'")]
        public void ThenRefreshForOptionIsAndNextRefreshIsAvailableAt(string option, string expectedStatus, DateTime nextActionTime, string accountID)
        {
            var refreshRepo = objectContainer.Resolve<IRefreshRepository>();
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            var parameterName = $"Delay_for_option_{option}_in_sec";

            var actualStatus = refreshRepo.GetRefreshStatus(option, accountID, configRepo.GetParameterValue(parameterName), _currentTime);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }

    public interface IRefreshRepository
    {
        void AddRefreshFact(string accountID, string option, DateTime actionTime);
        List<RefreshFact> GetAllForUserAndOption(string accountID, string option);
        string GetRefreshStatus(string option, string accountID, string refreshDelay, DateTime currentTime);
    }

    public class MemoryRefreshRepository : IRefreshRepository
    {
        private Dictionary<string,List<RefreshFact>> refreshes = new Dictionary<string, List<RefreshFact>>();

        public void AddRefreshFact(string accountID, string option, DateTime actionTime)
        {
            refreshes.Add(accountID, new List<RefreshFact> {
                new RefreshFact { AccountID = accountID, Option = option, LastAction = actionTime }
            });
        }

        public List<RefreshFact> GetAllForUserAndOption(string accountID, string option)
        {
            if (!refreshes.ContainsKey(accountID)) return new List<RefreshFact>();
            return refreshes[accountID].Where(x=>x.Option == option).ToList();
        }

        public string GetRefreshStatus(string option, string accountID, string refreshDelay, DateTime currentTime)
        {
            if (!refreshes.ContainsKey(accountID)) return "Enabled";
            else
            {
                return "Disabled";
            }
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
        string GetParameterValue(string parameterName);
        void SetConfigParameter(string parameter, string value);

    }

    public class MemoryConfigRepository : IConfigRepository
    {
        private Dictionary<string, string> _configValues = new Dictionary<string, string>();

        public string GetParameterValue(string parameterName)
        {
            return _configValues[parameterName];
        }

        public void SetConfigParameter(string parameter, string value)
        {
            _configValues.Add(parameter, value);
        }
    }
}