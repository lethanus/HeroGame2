﻿using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System.Collections;
using HeroesGame.Accounts;
using HeroesGame.Repositories;
using BoDi;
using System.IO;

namespace ConstructionYard
{
    [Binding]
    public class AccountManagementSteps : HeroesGameTestsBase
    {
        private Account loggedId = null;

        public AccountManagementSteps(IObjectContainer objectContainer) : base(objectContainer) { }

        [Given(@"Some accounts exists in system")]
        public void GivenSomeAccountsExistsInSystem(Table table)
        {
            var accountRepo = objectContainer.Resolve<IAccountRepository>();
            var accounts = table.CreateSet<Account>().ToList();
            foreach(var account in accounts)
            {
                accountRepo.Add(account);
            }
            Assert.Greater(accountRepo.GetAll().Count, 0);
        }
        
        [When(@"I try to login for '(.*)' and password '(.*)'")]
        public void WhenITryToLoginForAndPassword(string givenLogin, string givenPassword)
        {
            var accountManagement = objectContainer.Resolve<IAccountManagement>();
            loggedId = accountManagement.Login(givenLogin, givenPassword);
        }

        [Given(@"I try to login for '(.*)' and password '(.*)'")]
        public void GivenITryToLoginForAndPassword(string givenLogin, string givenPassword)
        {
            var accountManagement = objectContainer.Resolve<IAccountManagement>();
            loggedId = accountManagement.Login(givenLogin, givenPassword);
        }


        [Then(@"Logged account id is '(.*)'")]
        public void ThenLoggedAccountIdIs(string expectedAccountID)
        {
            if (expectedAccountID == "none") Assert.AreEqual(null, loggedId);
            else Assert.AreEqual(expectedAccountID, loggedId.ID);
        }
    }




}
