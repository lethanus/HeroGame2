using System;
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
    public class AccountManagementSteps
    {
        private Account loggedId = null;
        private readonly IObjectContainer objectContainer;

        public AccountManagementSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeAccountRepository()
        {
            TestInstaler.InitializeRepository(objectContainer);
        }

        [AfterScenario]
        public void CleanupAccountRepository()
        {
            TestInstaler.CleanupRepository();
        }

        [Given(@"Some accounts exists in system")]
        public void GivenSomeAccountsExistsInSystem(Table table)
        {
            var accountRepo = objectContainer.Resolve<IAccountRepository>();
            var accounts = table.CreateSet<Account>().ToList();
            foreach(var account in accounts)
            {
                accountRepo.AddAccount(account);
            }
            Assert.Greater(accountRepo.GetAccounts().Count, 0);
        }
        
        [When(@"I try to login for '(.*)' and password '(.*)'")]
        public void WhenITryToLoginForAndPassword(string givenLogin, string givenPassword)
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
