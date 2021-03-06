﻿using System;
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
    public class RefreshingMechanismSteps : HeroesGameTestsBase
    {
        private DateTime _currentTime = DateTime.Now;

        public RefreshingMechanismSteps(IObjectContainer objectContainer) : base(objectContainer) { }

        [Given(@"that there was no refresh actions before for option '(.*)' for account ID '(.*)'")]
        public void GivenThatThereWasNoRefreshActionsBeforeForOption(RefreshOption option, string accountID)
        {
            var refreshRepo = objectContainer.Resolve<IRefreshRepository>();
            var refreshes = refreshRepo.GetAll(accountID).Where(x=>x.Option == option).ToList();
            Assert.AreEqual(0, refreshes.Count);
        }

        [Given(@"that there are some refresh actions")]
        public void GivenThatThereWasAreSomeRefreshActionsBeforeForOptionForAccountID(Table table)
        {
            var refreshingMechnism = objectContainer.Resolve<IRefreshingMechnism>();
            var refreshFacts = table.CreateSet<RefreshFact>().ToList();
            foreach (var refresh in refreshFacts)
            {
                refreshingMechnism.AddRefreshFactForLoggedAccount(refresh.Option, refresh.LastAction);
            }
        }


        [Given(@"current time is set to '(.*)'")]
        public void GivenCurrentTimeIsSetTo(DateTime currentTime)
        {
            _currentTime = currentTime;
        }
        
        [Given(@"Refresh time for option '(.*)' is set to '(.*)' seconds")]
        public void GivenRefreshTimeForOptionIsSetToSeconds(RefreshOption option, string delayInSeconds)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"Delay_for_option_{option}_in_sec", delayInSeconds);
        }
        
        [When(@"mechanizm will set refresh to '(.*)' for option '(.*)'")]
        public void WhenMechanizmWillSetRefreshToForOption(RefresStatus expectedStatus, RefreshOption option)
        {
            var refreshingMechnism = objectContainer.Resolve<IRefreshingMechnism>();
            var actualStatus = refreshingMechnism.GetRefreshStatus(option, _currentTime);

            Assert.AreEqual(expectedStatus, actualStatus.Status);
        }
        
        [When(@"player will use refresh for '(.*)' option at '(.*)'")]
        public void WhenPlayerWillUseRefreshForOptionAt(RefreshOption option, DateTime actionTime)
        {
            var refreshingMechnism = objectContainer.Resolve<IRefreshingMechnism>();
            refreshingMechnism.AddRefreshFactForLoggedAccount(option, actionTime);
        }
        
        [Then(@"Refresh for option '(.*)' is '(.*)'")]
        public void ThenRefreshForOptionIsAndNextRefreshIsAvailableAt(RefreshOption option, RefresStatus expectedStatus)
        {
            var refreshingMechnism = objectContainer.Resolve<IRefreshingMechnism>();
            var actualStatus = refreshingMechnism.GetRefreshStatus(option, _currentTime);

            Assert.AreEqual(expectedStatus, actualStatus.Status);
        }
    }
}
